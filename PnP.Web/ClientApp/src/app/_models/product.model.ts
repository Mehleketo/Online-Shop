import { ApplicationUser } from "./user.model";

// Products
export interface Product {
  Id: number;
  Title: string;
  Description: string;
  Barcode: string;
  Price: string;
  HasDiscount: boolean;
  DiscountPrice: string;
  Image: string;
  Features: string;
  Usage: string;
  Slug: string;
  DateCreated: string;
  ReviewsCount: number;
  Reviews: ProductReview[];
}

export interface SupplierViewModel {
  Id: number;
  Title: string;
  Description: string;
  Barcode: string;
  Price: string;
  HasDiscount: boolean;
  DiscountPrice: string;
  Image: string;
  Features: string;
  Usage: string;
  Slug: string;
  DateCreated: string;
  ReviewsCount: number;
  Reviews: ProductReview[];
}

export interface ProductToCreate {
  Title: string;
  Description: string;
  ImageData: string;
  ImageType: string;
  Barcode: string;
  Price: string;
  ProductSubCategoryId: number;
  SupplierId: number;
}

// Product Reviews
export interface ProductReview {
  Id: number;
  Title: string;
  Comment: string;
  Rating: number;
  DateCreated: string;
  ProductId: number;
  UserId: string;
  UserFullName: string;
}

export interface ProductReviewViewModel {
  Id: number;
  Title: string;
  Comment: string;
  Rating: number;
  DateCreated: string;
  ProductId: number;
  UserId: string;
  Product: Product;
  User: ApplicationUser;
}

export interface ProductReviewToCreate {
  Title: string;
  Comment: string;
  Rating: number;
  ProductId: number;
  UserId: string;
}

// Product Categories
export interface ProductCategory {
  Id: number;
  Title: string;
  Description: string;
  Image: string;
  Slug: string;
  SubCategoryCount: number;
}

export interface ProductCategoryViewModel {
  Id: number;
  Title: string;
  Description: string;
  Image: string;
  Slug: string;
  SubCategoryCount: number;
}

export interface ProductCategoryToCreate {
  Title: string;
  Description: string;
  ImageData: string;
  ImageType: string;
}

// Product SubCategories
export interface ProductSubCategory {
  Id: number;
  Title: string;
  Description: string;
  ImageData: string;
  ImageType: string;
  Slug: string;
  ProductsCount: number;
}

export interface ProductSubCategoryViewModel {
  Id: number;
  Title: string;
  Description: string;
  ImageData: string;
  ImageType: string;
  Slug: string;
  ProductsCount: number;
}

export interface ProductSubCategoryToCreate {
  Title: string;
  Description: string;
  ImageData: string;
  ImageType: string;
  CategoryId: number;
}

// Favourite Products
export interface FavouriteProduct {
  Id: number;
  ProductTitle: string;
  ProductSlug: string;
  ProductImage: string;
}

export interface FavouriteProductViewModel {
  Id: number;
  ProductTitle: string;
  ProductSlug: string;
  ProductImage: string;
}

export interface FavouriteProductToCreate {
  ProductId: number;
  UserId: string;
}

// Grocery List
export interface GroceryList {
  Id: number;
  Title: string;
  GroceryListItemsCount: number;
  DateCreated: Date;
}

export interface GroceryListViewModel {
  Id: number;
  Title: string;
  GroceryListItemsCount: number;
  DateCreated: Date;
}

export interface GroceryListToCreate {
  Title: string;
  UserId: string;
}

// Grocery List Item
export interface GroceryListItem {
  Id: number;
  Quantity: number;
  DateCreated: Date;
  ProductTitle: string;
  ProductSlug: string;
  ProductImage: string;
}

export interface GroceryListItemViewModel {
  Id: number;
  Quantity: number;
  DateCreated: Date;
  ProductTitle: string;
  ProductSlug: string;
  ProductImage: string;
}

export interface GroceryListItemToCreate {
  Quantity: number;
  GroceryListId: string;
  ProductId: number;
}

// Supplier
export interface Supplier {
  Id: number;
  CompanyName: string;
  ContactName: string;
  ContactTitle: string;
  Address: string;
  City: string;
  Province: string;
  EmailAddress: string;
  PhoneNumber: string;
  FaxNumber: string;
  HomePage: string;
  Slug: string;
  ProductsCount: number;
}

export interface SupplierViewModel {
  Id: number;
  CompanyName: string;
  ContactName: string;
  ContactTitle: string;
  Address: string;
  City: string;
  Province: string;
  EmailAddress: string;
  PhoneNumber: string;
  FaxNumber: string;
  HomePage: string;
  Slug: string;
  ProductsCount: number;
}

export interface SupplierToCreate {
  CompanyName: string;
  ContactName: string;
  ContactTitle: string;
  Address: string;
  City: string;
  Province: string;
  EmailAddress: string;
  PhoneNumber: string;
  FaxNumber: string;
  HomePage: string;
}
