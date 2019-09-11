import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service';

import { ProductCategoryViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-category',
  templateUrl: './view-category.component.html',
  styleUrls: ['./view-category.component.css']
})
export class ViewCategoryComponent implements OnInit {

  categories: ProductCategoryViewModel[];
  slugObservable: string;
  loading: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductService
  ) { }

  ngOnInit() {
    this.productService.GetCategories2()
      .subscribe(categ => {
        this.categories = categ;

        console.log(this.categories);
      });
    //this.route.params.subscribe(params => {
    //  this.slugObservable = params['slug'];
    //  console.log(this.slugObservable);
    //  this.productService.GetCategoryBySlug(this.slugObservable)
    //    .subscribe(categ => {
    //      this.category = categ;

    //      console.log(this.category);
    //    });
    //});
  }

  onDelete(id: number) {

    this.loading = true;

    this.productService.DeleteCategory(id)
      .subscribe(resp => {
        this.productService.GetCategories2()
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
