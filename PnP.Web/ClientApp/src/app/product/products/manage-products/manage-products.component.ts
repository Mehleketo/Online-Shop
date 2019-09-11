import { Component, OnInit } from '@angular/core';

import { ProductService } from '../../../_services/product.service';

import { SupplierViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-manage-products',
  templateUrl: './manage-products.component.html',
  styleUrls: ['./manage-products.component.css']
})
export class ManageProductsComponent implements OnInit {

  products: SupplierViewModel[];
  loading: boolean = false;

  constructor(
    private productService: ProductService
  ) { }

  ngOnInit() {
    //this.categories = this.productService.GetCategories();
    this.productService.GetProducts()
      .subscribe(prod => {
        this.products = prod;
      });
  }

  addToCart(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Add To Cart: ${id}`);

      this.loading = false;
    }, 5000);
  }

  onDelete(id: number) {

    this.loading = true;

    this.productService.DeleteProduct(id)
      .subscribe(resp => {
        this.productService.GetProducts()
          .subscribe(prod => {
            this.products = prod;

            this.loading = false;
          });
      });
  }

  onUpdate(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Update Category: ${id}`);

      this.loading = false;
    }, 5000);
  }
}
