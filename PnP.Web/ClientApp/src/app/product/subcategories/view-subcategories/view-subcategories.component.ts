import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ProductService } from '../../../_services/product.service';

import { ProductSubCategoryViewModel } from '../../../_models/product.model';

@Component({
  selector: 'app-view-subcategories',
  templateUrl: './view-subcategories.component.html',
  styleUrls: ['./view-subcategories.component.css']
})
export class ViewSubcategoriesComponent implements OnInit {

  subcategories: ProductSubCategoryViewModel[];
  slugObservable: string;

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
