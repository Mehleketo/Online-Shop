import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service';
import { JwtService } from '../../../_services/jwt.service';

import { SupplierViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {

  products: SupplierViewModel[];
  slugObservable: string;
  loading: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private jwtService: JwtService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.slugObservable = params['slug'];
      console.log(this.slugObservable);
      this.productService.GetProductBySubCategorySlug(this.slugObservable)
        .subscribe(prod => {
          this.products = prod;

          console.log(this.products);
        });
    });
  }

  addToCart(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Add To Cart: ${id}`);

      this.loading = false;
    }, 5000);
  }

  addToFavourites(id: number) {

    this.loading = true;

    //this.favouriteProductToCreate = {
    //  ProductId: id,
    //  UserId: this.jwtService.getUserId()
    //};

    //this.productService.CreateFavouriteProduct(this.favouriteProductToCreate)
    //  .subscribe(resp => {
    //    this.loading = false;
    //  });
  }
}
