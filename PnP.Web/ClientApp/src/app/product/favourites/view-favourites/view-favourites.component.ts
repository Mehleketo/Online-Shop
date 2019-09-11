import { Component, OnInit } from '@angular/core';

import { ProductService } from '../../../_services/product.service';
import { JwtService } from '../../../_services/jwt.service';

import { FavouriteProduct, FavouriteProductViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-favourites',
  templateUrl: './view-favourites.component.html',
  styleUrls: ['./view-favourites.component.css']
})
export class ViewFavouritesComponent implements OnInit {

  favourites: FavouriteProductViewModel[];
  loading: boolean = false;

  constructor(
    private productService: ProductService,
    private jwtService: JwtService
  ) { }

  ngOnInit() {
    this.productService.GetFavouriteProductsByUserId(this.jwtService.getUserId())
      .subscribe(fav => {
        this.favourites = fav;

        console.log(this.favourites);
      });
  }

  addToCart(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Add To Cart: ${id}`);

      this.loading = false;
    }, 5000);
  }

  removeFromFavourites(id: number) {

    this.loading = true;

    this.productService.DeleteFavouriteProduct(id)
      .subscribe(resp => {
        this.productService.GetFavouriteProducts()
          .subscribe(fav => {
            this.favourites = fav;

            this.loading = false;
          });
      });
  }
}
