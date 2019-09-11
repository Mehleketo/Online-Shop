import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service';

import { ProductCategory, ProductSubCategoryViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-subcategory',
  templateUrl: './view-subcategory.component.html',
  styleUrls: ['./view-subcategory.component.css']
})
export class ViewSubcategoryComponent implements OnInit {

  category: ProductCategory;
  subcategories: any[];
  slugObservable: string;
  loading: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.slugObservable = params['slug'];
      console.log(this.slugObservable);
      this.productService.GetSubCatByCategorySlug(this.slugObservable)
        .subscribe(categ => {
          this.subcategories = categ;

          console.log(this.subcategories);
        });
    });
  }

  onManage(slug: string) {

    this.router.navigate(['products/manage/', { slug: slug }]);
  }
}
