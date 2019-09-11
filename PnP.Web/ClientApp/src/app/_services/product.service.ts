import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';

import { environment } from '../../environments/environment';

import {
  Product, ProductToCreate, SupplierViewModel,
  ProductCategory, ProductCategoryViewModel, ProductCategoryToCreate,
  ProductSubCategory, ProductSubCategoryViewModel, ProductSubCategoryToCreate,
  ProductReview, ProductReviewViewModel, ProductReviewToCreate,
  FavouriteProduct, FavouriteProductViewModel, FavouriteProductToCreate,
  GroceryList, GroceryListViewModel, GroceryListToCreate,
  GroceryListItem, GroceryListItemViewModel, GroceryListItemToCreate,
  Supplier, SupplierViewModel, SupplierToCreate
} from '../_models/product.model';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private http: HttpClient
  ) { }

  // Products

  GetProducts(): Observable<SupplierViewModel[]> {
    return this.http.get('api/products')
      .pipe(map(data => {
        return data as SupplierViewModel[];
      }));
  };

  GetProduct(_id: string): Observable<SupplierViewModel> {
    return this.http.get(`api/products/${_id}`)
      .pipe(map(data => {
        return data as SupplierViewModel;
      }));
  }

  GetProductByName(_name: string): Observable<Product> {
    return this.http.get(`api/products/${_name}`)
      .pipe(map(data => {
        return data as Product;
      }));
  }

  GetProductByBarcode(_barcode: string): Observable<SupplierViewModel> {
    return this.http.get(`api/products/barcode/${_barcode}`)
      .pipe(map(data => {
        return data as SupplierViewModel;
      }));
  }

  GetProductBySlug(_slug: string): Observable<SupplierViewModel> {
    return this.http.get(`api/products/slug/${_slug}`)
      .pipe(map(data => {
        return data as SupplierViewModel;
      }));
  }

  GetProductBySubCategorySlug(_slug: string): Observable<SupplierViewModel[]> {
    return this.http.get(`api/products/subcategories/slug/${_slug}`)
      .pipe(map(data => {
        return data as SupplierViewModel[];
      }));
  }

  CreateProduct(product: ProductToCreate): Observable<any> {
    console.log(product);

    return this.http.post('api/products', product)
      .pipe(map(data => {
        return data;
      }));
  }

  UpdateProduct(product: Product): Observable<Product> {
    return this.http.put('api/products', product)
      .pipe(map(data => {
        return data as Product;
      }));
  }

  DeleteProduct(_id: number): Observable<Product> {
    return this.http.delete(`api/products/${_id}`)
      .pipe(map(data => {
        return data as Product;
      }));
  }

  // Product Categories

  public category: ProductCategory;
  public categories: ProductCategory[] = [];

  GetCategories(): Observable<ProductCategory[]> {
    return this.http.get('api/productcategories')
      .pipe(map(data => {
        return data as ProductCategory[];
      }));
  };

  GetCategories2(): Observable<ProductCategoryViewModel[]> {
    return this.http.get('api/productcategories')
      .pipe(map(data => {
        return data as ProductCategoryViewModel[];
      }));
  };

  GetCategory(_id: number): Observable<ProductCategory> {
    return this.http.get(`api/productcategories/${_id}`)
      .pipe(map(data => {
        return data as ProductCategory;
      }));
  }

  GetCategoryBySlug(_slug: string): Observable<ProductCategory> {
    return this.http.get(`api/productcategories/slug/${_slug}`)
      .pipe(map(data => {
        return data as ProductCategory;
      }));
  }

  CreateCategory(category: ProductCategoryToCreate): Observable<any> {
    console.log(category);

    return this.http.post('api/productcategories', category)
      .pipe(map(data => {
        return data;
      }));
  }

  UpdateCategory(category: ProductCategory): Observable<any> {
    return this.http.put('api/productcategories', category)
      .pipe(map(data => {
        return data;
      }));
  }

  DeleteCategory(_id: number): Observable<ProductCategory> {
    return this.http.delete(`api/productcategories/${_id}`)
      .pipe(map(data => {
        return data as ProductCategory;
      }));
  }

  // Product Sub Categories

  public subcategory: ProductSubCategory;
  public subcategories: ProductSubCategory[] = [];

  GetSubCategories(): Observable<ProductSubCategory[]> {
    return this.http.get('api/productsubcategories')
      .pipe(map(data => {
        return data as ProductSubCategory[];
      }));
  };

  GetSubCategory(_id: number): Observable<ProductSubCategory> {
    return this.http.get(`api/productsubcategories/${_id}`)
      .pipe(map(data => {
        return data as ProductSubCategory;
      }));
  }

  GetSubCatByCategorySlug(_slug: string): Observable<ProductSubCategoryViewModel[]> {
    return this.http.get(`api/productsubcategories/category/${_slug}`)
      .pipe(map(data => {
        return data as ProductSubCategoryViewModel[];
      }));
  }

  GetSubcategoryBySlug(_slug: string): Observable<ProductSubCategory> {
    return this.http.get(`api/productsubcategories/slug/${_slug}`)
      .pipe(map(data => {
        return data as ProductSubCategory;
      }));
  }

  CreateSubCategory(subcategory: ProductSubCategoryToCreate): Observable<any> {
    console.log(subcategory);

    return this.http.post('api/productsubcategories', subcategory)
      .pipe(map(data => {
        return data;
      }));
  }

  UpdateSubCategory(subcategory: ProductSubCategory): Observable<any> {
    return this.http.put('api/productsubcategories', subcategory)
      .pipe(map(data => {
        return data;
      }));
  }

  DeleteSubCategory(_id: number): Observable<any> {
    return this.http.delete(`api/productsubcategories/${_id}`)
      .pipe(map(data => {
        return data;
      }));
  }

  // Product Reviews

  public review: ProductReview;
  public reviews: ProductReview[] = [];

  GetReviews(): Observable<ProductReview[]> {
    return this.http.get('api/productreviews')
      .pipe(map(data => {
        return data as ProductReview[];
      }));
  };

  GetReviewByProductId(_productId: number): Observable<ProductReview[]> {
    return this.http.get(`api/productreviews/?productId=${_productId}`)
      .pipe(map(data => {
        return data as ProductReview[];
      }));
  };

  GetReview(_id: number): Observable<ProductReview> {
    return this.http.get(`api/productreviews/${_id}`)
      .pipe(map(data => {
        return data as ProductReview;
      }));
  }

  CreateReview(subcategory: ProductReviewToCreate): Observable<ProductReview> {
    console.log(subcategory);

    return this.http.post('api/productreviews', subcategory)
      .pipe(map(data => {
        return data as ProductReview;
      }));
  }

  UpdateReview(subcategory: ProductSubCategory): Observable<ProductReview> {
    return this.http.put('api/productreviews', subcategory)
      .pipe(map(data => {
        return data as ProductReview;
      }));
  }

  DeleteReview(_id: number): Observable<ProductReview> {
    return this.http.delete(`api/productreviews/${_id}`)
      .pipe(map(data => {
        return data as ProductReview;
      }));
  }

  // Favourite Products

  public favourite: FavouriteProduct;
  public favourites: FavouriteProduct[] = [];

  GetFavouriteProducts(): Observable<FavouriteProductViewModel[]> {
    return this.http.get('api/favouriteproducts')
      .pipe(map(data => {
        return data as FavouriteProductViewModel[];
      }));
  };

  GetFavouriteProductsByUserId(_userId: string): Observable<FavouriteProductViewModel[]> {
    return this.http.get(`api/favouriteproducts/${_userId}`)
      .pipe(map(data => {
        return data as FavouriteProductViewModel[];
      }));
  };

  GetFavouriteProduct(_id: number): Observable<FavouriteProductViewModel> {
    return this.http.get(`api/favouriteproducts/${_id}`)
      .pipe(map(data => {
        return data as FavouriteProductViewModel;
      }));
  }

  CreateFavouriteProduct(favouriteProduct: FavouriteProductToCreate): Observable<FavouriteProduct> {
    console.log(favouriteProduct);

    return this.http.post('api/favouriteproducts', favouriteProduct)
      .pipe(map(data => {
        return data as FavouriteProduct;
      }));
  }

  UpdateFavouriteProduct(favouriteProduct: FavouriteProduct): Observable<FavouriteProduct> {
    return this.http.put('api/favouriteproducts', favouriteProduct)
      .pipe(map(data => {
        return data as FavouriteProduct;
      }));
  }

  DeleteFavouriteProduct(_id: number): Observable<FavouriteProduct> {
    return this.http.delete(`api/favouriteproducts/${_id}`)
      .pipe(map(data => {
        return data as FavouriteProduct;
      }));
  }

  // Grocery List

  public groceryList: GroceryList;
  public groceryLists: GroceryList[] = [];

  GetGroceryLists(): Observable<GroceryListViewModel[]> {
    return this.http.get('api/grocerylists')
      .pipe(map(data => {
        return data as GroceryListViewModel[];
      }));
  };

  GetGroceryListsByUserId(_userId: string): Observable<GroceryListViewModel[]> {
    return this.http.get(`api/grocerylists/${_userId}`)
      .pipe(map(data => {
        return data as GroceryListViewModel[];
      }));
  };

  GetGroceryList(_id: number): Observable<GroceryListViewModel> {
    return this.http.get(`api/grocerylists/?id=${_id}`)
      .pipe(map(data => {
        return data as GroceryListViewModel;
      }));
  }

  CreateGroceryList(groceryListToCreate: GroceryListToCreate): Observable<GroceryList> {
    console.log(groceryListToCreate);

    return this.http.post('api/grocerylists', groceryListToCreate)
      .pipe(map(data => {
        return data as GroceryList;
      }));
  }

  UpdateGroceryList(groceryList: GroceryList): Observable<GroceryList> {
    return this.http.put('api/grocerylists', groceryList)
      .pipe(map(data => {
        return data as GroceryList;
      }));
  }

  DeleteGroceryList(_id: number): Observable<GroceryList> {
    return this.http.delete(`api/grocerylists/${_id}`)
      .pipe(map(data => {
        return data as GroceryList;
      }));
  }

  // Grocery List Item

  public groceryListItem: GroceryListItem;
  public groceryListItems: GroceryListItem[] = [];

  GetGroceryListItems(): Observable<GroceryListItemViewModel[]> {
    return this.http.get('api/grocerylistitems')
      .pipe(map(data => {
        return data as GroceryListItemViewModel[];
      }));
  };

  GetGroceryListItemsByGroceryListId(_groceryListId: number): Observable<GroceryListItemViewModel[]> {
    return this.http.get(`api/grocerylistitems/groceryList/${_groceryListId}`)
      .pipe(map(data => {
        return data as GroceryListItemViewModel[];
      }));
  };

  GetGroceryListItem(_id: number): Observable<GroceryListItemViewModel> {
    return this.http.get(`api/grocerylistitems/${_id}`)
      .pipe(map(data => {
        return data as GroceryListItemViewModel;
      }));
  }

  CreateGroceryListItem(groceryListItemToCreate: GroceryListItemToCreate): Observable<GroceryListItem> {
    console.log(groceryListItemToCreate);

    return this.http.post('api/grocerylistitems', groceryListItemToCreate)
      .pipe(map(data => {
        return data as GroceryListItem;
      }));
  }

  UpdateGroceryListItem(groceryListItem: GroceryList): Observable<GroceryListItem> {
    return this.http.put('api/grocerylistitems', groceryListItem)
      .pipe(map(data => {
        return data as GroceryListItem;
      }));
  }

  DeleteGroceryListItem(_id: number): Observable<GroceryListItem> {
    return this.http.delete(`api/grocerylistitems/${_id}`)
      .pipe(map(data => {
        return data as GroceryListItem;
      }));
  }

  // Supplier

  public supplier: Supplier;
  public suppliers: Supplier[] = [];

  GetSuppliers(): Observable<SupplierViewModel[]> {
    return this.http.get('api/suppliers')
      .pipe(map(data => {
        return data as SupplierViewModel[];
      }));
  };

  GetSupplier(_id: number): Observable<SupplierViewModel> {
    return this.http.get(`api/suppliers/${_id}`)
      .pipe(map(data => {
        return data as SupplierViewModel;
      }));
  }

  GetSupplierBySlug(_slug: string): Observable<SupplierViewModel> {
    return this.http.get(`api/suppliers/slug/${_slug}`)
      .pipe(map(data => {
        return data as SupplierViewModel;
      }));
  }

  CreateSupplier(supplierToCreate: SupplierToCreate): Observable<Supplier> {
    console.log(supplierToCreate);

    return this.http.post('api/suppliers', supplierToCreate)
      .pipe(map(data => {
        return data as Supplier;
      }));
  }

  UpdateSupplier(supplier: Supplier): Observable<Supplier> {
    return this.http.put('api/suppliers', supplier)
      .pipe(map(data => {
        return data as Supplier;
      }));
  }

  DeleteSupplier(_id: number): Observable<Supplier> {
    return this.http.delete(`api/suppliers/${_id}`)
      .pipe(map(data => {
        return data as Supplier;
      }));
  }

}
