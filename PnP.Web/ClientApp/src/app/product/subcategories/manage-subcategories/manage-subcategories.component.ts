import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ProductService } from '../../../_services/product.service';

import { ProductSubCategory } from '../../../_models/product.model';

@Component({
  selector: 'app-manage-subcategories',
  templateUrl: './manage-subcategories.component.html',
  styleUrls: ['./manage-subcategories.component.css']
})
export class ManageSubcategoriesComponent implements OnInit {

  subcategories: ProductSubCategory[];
  loading: boolean = false;

  constructor(
    private router: Router,
    private productService: ProductService
  ) { }

  ngOnInit() {
    //this.categories = this.productService.GetCategories();
    this.productService.GetSubCategories()
      .subscribe(categ => {
        this.subcategories = categ;
      });
  }

  onDelete(id: number) {

    this.loading = true;

    this.productService.DeleteSubCategory(id)
      .subscribe(resp => {
        this.productService.GetSubCategories()
          .subscribe(categ => {
            this.subcategories = categ;

            this.loading = false;
          });
      });
  }

  onUpdate(id: number) {

    this.loading = true;

    setTimeout(() => {
      console.log(`Update Subcategory: ${id}`);

      this.loading = false;
    }, 5000);
  }

  onManage(slug: string) {

    this.router.navigate(['products/manage/', { slug: slug }]);
  }
}
