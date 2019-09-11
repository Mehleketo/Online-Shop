import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ProductService } from '../../../_services/product.service';

import { ProductReview } from '../../../_models/product.model';

@Component({
  selector: 'view-reviews',
  templateUrl: './view-reviews.component.html',
  styleUrls: ['./view-reviews.component.css']
})
export class ViewReviewsComponent implements OnInit {

  reviews: ProductReview[];
  //productId: number = 1;
  slugObservable: string;
  loading: boolean = false;

  @Input() productId: string = "1";

  //set productId(productId: number) {
  //  this._productId = productId;
  //}

  //get productId(): number { return this._productId; }

  constructor(
    private router: Router,
    private productService: ProductService
  ) { }

  ngOnInit() {

    console.log(this.productId);

    this.productService.GetReviewByProductId(parseInt(this.productId))
      .subscribe(categ => {
        this.reviews = categ;

        console.log(this.reviews);
      });
  }

}
