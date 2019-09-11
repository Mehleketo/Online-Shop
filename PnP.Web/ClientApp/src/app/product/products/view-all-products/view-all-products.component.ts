import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { DomSanitizer } from '@angular/platform-browser';
import { Router, ActivatedRoute } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service';
import { JwtService } from '../../../_services/jwt.service';

import { SupplierViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-all-products',
  templateUrl: './view-all-products.component.html',
  styleUrls: ['./view-all-products.component.css']
})
export class ViewAllProductsComponent implements OnInit {

  products: SupplierViewModel[];
  loading: boolean = false;

  constructor(
    private productService: ProductService,
    private jwtService: JwtService
  ) { }

  ngOnInit() {
    this.productService.GetProducts()
      .subscribe(prod => {
        this.products = prod;

        console.log(this.products);
      });
  }

  addToCart(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Add To Cart: ${id}`);

      this.loading = false;
    }, 5000);
  }

}
