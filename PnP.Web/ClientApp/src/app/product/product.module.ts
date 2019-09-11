import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ProductRoutingModule } from './product.routing.module';

import { CreateProductComponent } from './products/create-product/create-product.component';
import { EditProductComponent } from './products/edit-product/edit-product.component';
import { ViewProductComponent } from './products/view-product/view-product.component';
import { ViewProductsComponent } from './products/view-products/view-products.component';
import { ViewAllProductsComponent } from './products/view-all-products/view-all-products.component';
import { ManageProductsComponent } from './products/manage-products/manage-products.component';

import { CreateCategoryComponent } from './categories/create-category/create-category.component';
import { EditCategoryComponent } from './categories/edit-category/edit-category.component';
import { ViewCategoryComponent } from './categories/view-category/view-category.component';
import { ViewCategoriesComponent } from './categories/view-categories/view-categories.component';
import { ManageCategoriesComponent } from './categories/manage-categories/manage-categories.component';

import { CreateDiscountComponent } from './discounts/create-discount/create-discount.component';
import { EditDiscountComponent } from './discounts/edit-discount/edit-discount.component';
import { ViewDiscountComponent } from './discounts/view-discount/view-discount.component';
import { ViewDiscountsDateComponent } from './discounts/view-discounts-date/view-discounts-date.component';
import { ViewDiscountsTodayComponent } from './discounts/view-discounts-today/view-discounts-today.component';
import { ManageDiscountsComponent } from './discounts/manage-discounts/manage-discounts.component';

import { CreateFavouriteComponent } from './favourites/create-favourite/create-favourite.component';
import { ViewFavouritesComponent } from './favourites/view-favourites/view-favourites.component';
import { ManageFavouritesComponent } from './favourites/manage-favourites/manage-favourites.component';

import { CreateGroceryListComponent } from './grocerylists/create-grocery-list/create-grocery-list.component';
import { EditGroceryListComponent } from './grocerylists/edit-grocery-list/edit-grocery-list.component';
import { ViewGroceryListComponent } from './grocerylists/view-grocery-list/view-grocery-list.component';
import { ViewGroceryListsComponent } from './grocerylists/view-grocery-lists/view-grocery-lists.component';

import { CreateGroceryListItemComponent } from './grocerylistitems/create-grocery-list-item/create-grocery-list-item.component';
import { ViewGroceryListItemsComponent } from './grocerylistitems/view-grocery-list-items/view-grocery-list-items.component';

import { CreateReviewComponent } from './reviews/create-review/create-review.component';
import { EditReviewComponent } from './reviews/edit-review/edit-review.component';
import { ViewReviewComponent } from './reviews/view-review/view-review.component';
import { ViewReviewsComponent } from './reviews/view-reviews/view-reviews.component';
import { ManageReviewsComponent } from './reviews/manage-reviews/manage-reviews.component';

import { CreateSubcategoryComponent } from './subcategories/create-subcategory/create-subcategory.component';
import { EditSubcategoryComponent } from './subcategories/edit-subcategory/edit-subcategory.component';
import { ViewSubcategoryComponent } from './subcategories/view-subcategory/view-subcategory.component';
import { ViewSubcategoriesComponent } from './subcategories/view-subcategories/view-subcategories.component';
import { ManageSubcategoriesComponent } from './subcategories/manage-subcategories/manage-subcategories.component';

import { CreateSupplierComponent } from './suppliers/create-supplier/create-supplier.component';
import { EditSupplierComponent } from './suppliers/edit-supplier/edit-supplier.component';
import { ManageSuppliersComponent } from './suppliers/manage-suppliers/manage-suppliers.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ProductRoutingModule
  ],
  declarations: [
    CreateProductComponent,
    EditProductComponent,
    ViewProductComponent,
    ViewProductsComponent,
    ViewAllProductsComponent,
    ManageProductsComponent,
    CreateCategoryComponent,
    EditCategoryComponent,
    ViewCategoryComponent,
    ViewCategoriesComponent,
    ManageCategoriesComponent,
    CreateDiscountComponent,
    EditDiscountComponent,
    ViewDiscountComponent,
    ViewDiscountsDateComponent,
    ViewDiscountsTodayComponent,
    ManageDiscountsComponent,
    CreateFavouriteComponent,
    ViewFavouritesComponent,
    ManageFavouritesComponent,
    CreateGroceryListComponent,
    EditGroceryListComponent,
    ViewGroceryListComponent,
    ViewGroceryListsComponent,
    CreateGroceryListItemComponent,
    ViewGroceryListItemsComponent,
    CreateReviewComponent,
    EditReviewComponent,
    ViewReviewComponent,
    ViewReviewsComponent,
    ManageReviewsComponent,
    CreateSubcategoryComponent,
    EditSubcategoryComponent,
    ViewSubcategoryComponent,
    ViewSubcategoriesComponent,
    ManageSubcategoriesComponent,
    CreateSupplierComponent,
    EditSupplierComponent,
    ManageSuppliersComponent
  ]
})
export class ProductModule { }
