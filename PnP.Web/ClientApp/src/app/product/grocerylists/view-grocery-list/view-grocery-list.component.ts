import { Component, OnInit } from '@angular/core';

import { ProductService } from '../../../_services/product.service';
import { JwtService } from '../../../_services/jwt.service';

import { GroceryListViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-grocery-list',
  templateUrl: './view-grocery-list.component.html',
  styleUrls: ['./view-grocery-list.component.css']
})
export class ViewGroceryListComponent implements OnInit {

  groceryLists: GroceryListViewModel[];
  loading: boolean = false;

  constructor(
    private productService: ProductService,
    private jwtService: JwtService
  ) { }

  ngOnInit() {
    this.productService.GetGroceryListsByUserId(this.jwtService.getUserId())
      .subscribe(res => {
        this.groceryLists = res;

        console.log(this.groceryLists);
      });
  }

  addToCart(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Add To Cart: ${id}`);

      this.loading = false;
    }, 3000);
  }

  onViewItems(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`View Grocery List Items: ${id}`);

      this.loading = false;
    }, 3000);
  }

  onDelete(id: number) {

    this.loading = true;

    this.productService.DeleteGroceryListItem(id)
      .subscribe(resp => {
        this.productService.GetGroceryListsByUserId(this.jwtService.getUserId())
          .subscribe(res => {
            this.groceryLists = res;

            console.log(this.groceryLists);
          });
      });
  }

  onUpdate(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Update Grocery List: ${id}`);

      this.loading = false;
    }, 3000);
  }

  onAddToTrolley(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Add List: ${id} To Trolley`);

      this.loading = false;
    }, 3000);
  }

  onCopy(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Copy List: ${id}`);

      this.loading = false;
    }, 3000);
  }
}
