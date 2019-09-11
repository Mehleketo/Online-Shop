import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service';
import { JwtService } from '../../../_services/jwt.service';

import { GroceryListItemViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-grocery-lists',
  templateUrl: './view-grocery-lists.component.html',
  styleUrls: ['./view-grocery-lists.component.css']
})
export class ViewGroceryListsComponent implements OnInit {

  groceryListItems: GroceryListItemViewModel[];
  loading: boolean = false;
  idObservable: number;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private jwtService: JwtService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.idObservable = params['id'];
      console.log(this.idObservable);

      this.productService.GetGroceryListItemsByGroceryListId(this.idObservable)
        .subscribe(res => {
          this.groceryListItems = res;

          console.log(this.groceryListItems);
        });
    });
  }

  onDelete(id: number) {

    this.loading = true;

    this.productService.DeleteGroceryListItem(id)
      .subscribe(resp => {
        this.productService.GetGroceryListItemsByGroceryListId(this.idObservable)
          .subscribe(res => {
            this.groceryListItems = res;

            console.log(this.groceryListItems);
          });
      });
  }
}
