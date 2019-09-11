import { Component, OnInit } from '@angular/core';

import { ProductService } from '../../../_services/product.service';

import { SupplierViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-manage-suppliers',
  templateUrl: './manage-suppliers.component.html',
  styleUrls: ['./manage-suppliers.component.css']
})
export class ManageSuppliersComponent implements OnInit {

  suppliers: SupplierViewModel[];
  loading: boolean = false;

  constructor(
    private productService: ProductService
  ) { }

  ngOnInit() {
    this.productService.GetSuppliers()
      .subscribe(prod => {
        this.suppliers = prod;
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

    this.productService.DeleteSupplier(id)
      .subscribe(resp => {
        this.productService.GetSuppliers()
          .subscribe(prod => {
            this.suppliers = prod;

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
