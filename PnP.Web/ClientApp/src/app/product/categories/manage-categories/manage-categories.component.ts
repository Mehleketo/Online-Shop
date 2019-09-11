import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ProductService } from '../../../_services/product.service';

import { ProductCategory } from '../../../_models/product.model';


@Component({
  selector: 'app-manage-categories',
  templateUrl: './manage-categories.component.html',
  styleUrls: ['./manage-categories.component.css']
})
export class ManageCategoriesComponent implements OnInit {

  categories: ProductCategory[];
  loading: boolean = false;

  constructor(
    private router: Router,
    private productService: ProductService
  ) { }

  ngOnInit() {
    //this.categories = this.productService.GetCategories();
    this.productService.GetCategories()
      .subscribe(categ => {
        this.categories = categ;

        console.log(this.categories);
      });
  }

  onDelete(id: number) {

    this.loading = true;

    this.productService.DeleteCategory(id)
      .subscribe(resp => {
        this.productService.GetCategories()
          .subscribe(categ => {
            this.categories = categ;

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

  onManage(slug: string) {

    this.router.navigate(['/subcategories/view/', { slug: slug }]);
  }
}
