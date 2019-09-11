import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service';
import { JwtService } from '../../../_services/jwt.service';

import { SupplierViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {

  product: SupplierViewModel;
  productId: string;
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
      this.productService.GetProductBySlug(this.slugObservable)
        .subscribe(categ => {
          this.product = categ;
          this.productId = categ.Id.toString();

          console.log(this.product);
          console.log(this.productId);
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
