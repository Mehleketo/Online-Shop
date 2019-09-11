import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../_guards/auth.guard';
import { NoAuthGuard } from '../_guards/no.auth.guard';
import { AdminAuthGuard } from '../_guards/admin.auth.guard';

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

const routes: Routes = [
  { path: 'products/create', component: CreateProductComponent, canActivate: [AuthGuard] },
  { path: 'products/edit', component: EditProductComponent, canActivate: [AuthGuard] },
  { path: 'product/:slug', component: ViewProductComponent, canActivate: [AuthGuard] },
  { path: 'products/:slug', component: ViewProductsComponent, canActivate: [AuthGuard] },
  { path: 'products/all', component: ViewAllProductsComponent, canActivate: [AuthGuard] },
  { path: 'products/manage/:slug', component: ManageProductsComponent, canActivate: [AuthGuard] },

  { path: 'category/create', component: CreateCategoryComponent, canActivate: [AuthGuard] },
  { path: 'category/edit', component: EditCategoryComponent, canActivate: [AuthGuard] },
  { path: 'category/:slug', component: ViewCategoryComponent, canActivate: [AuthGuard] },
  { path: 'categories', component: ViewCategoriesComponent, canActivate: [AuthGuard] },
  { path: 'categories/manage/:slug', component: ManageCategoriesComponent, canActivate: [AuthGuard] },

  { path: 'discount/create', component: CreateDiscountComponent, canActivate: [AuthGuard] },
  { path: 'discount/edit', component: EditDiscountComponent, canActivate: [AuthGuard] },
  { path: 'discount/:id', component: ViewDiscountComponent, canActivate: [AuthGuard] },
  { path: 'discounts/date/:date', component: ViewDiscountsDateComponent, canActivate: [AuthGuard] },
  { path: 'discounts/today', component: ViewDiscountsTodayComponent, canActivate: [AuthGuard] },
  { path: 'discounts/manage/:slug', component: ManageDiscountsComponent, canActivate: [AuthGuard] },

  { path: 'favourites/create', component: CreateFavouriteComponent, canActivate: [AuthGuard] },
  { path: 'favourites', component: ViewFavouritesComponent, canActivate: [AuthGuard] },
  { path: 'favourites/manage', component: ManageFavouritesComponent, canActivate: [AuthGuard] },

  { path: 'grocerylist/create', component: CreateGroceryListComponent, canActivate: [AuthGuard] },
  { path: 'grocerylist/edit', component: EditGroceryListComponent, canActivate: [AuthGuard] },
  { path: 'grocerylist', component: ViewGroceryListComponent, canActivate: [AuthGuard] },
  { path: 'grocerylists/:id', component: ViewGroceryListsComponent, canActivate: [AuthGuard] },

  { path: 'grocerylistitem/create', component: CreateGroceryListItemComponent, canActivate: [AuthGuard] },
  { path: 'grocerylistitem/:id', component: ViewGroceryListItemsComponent, canActivate: [AuthGuard] },

  { path: 'review/create', component: CreateReviewComponent, canActivate: [AuthGuard] },
  { path: 'review/edit', component: EditReviewComponent, canActivate: [AuthGuard] },
  { path: 'review/:id', component: ViewReviewComponent, canActivate: [AuthGuard] },
  { path: 'reviews', component: ViewReviewsComponent, canActivate: [AuthGuard] },
  { path: 'reviews/manage', component: ManageReviewsComponent, canActivate: [AuthGuard] },

  { path: 'subcategory/create', component: CreateSubcategoryComponent, canActivate: [AuthGuard] },
  { path: 'subcategory/edit', component: EditSubcategoryComponent, canActivate: [AuthGuard] },
  { path: 'subcategory/:slug', component: ViewSubcategoryComponent, canActivate: [AuthGuard] },
  { path: 'subcategories', component: ViewSubcategoriesComponent, canActivate: [AuthGuard] },
  { path: 'subcategories/manage/:slug', component: ManageSubcategoriesComponent, canActivate: [AuthGuard] },

  { path: 'suppliers/create', component: CreateSupplierComponent, canActivate: [AuthGuard] },
  { path: 'suppliers/edit', component: EditSupplierComponent, canActivate: [AuthGuard] },
  { path: 'suppliers/manage', component: ManageSuppliersComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
