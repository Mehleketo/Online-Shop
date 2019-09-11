using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PnP.Web.Models.Products;
using PnP.Data.Interfaces;
using PnP.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;
using System.Text;

namespace PnP.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IFavouriteProductService _favouriteService;
        private readonly IGroceryListItemService _groceryListItemService;
        private readonly IGroceryListService _groceryListService;
        private readonly IProductCategoryService _categoryService;
        private readonly IProductDiscountService _discountService;
        private readonly IProductReviewService _reviewService;
        private readonly IProductSubcategoryService _subcategoryService;
        private readonly ISupplierService _supplierService;

        public ProductsController(
            IProductService productService,
            IFavouriteProductService favouriteService,
            IGroceryListItemService groceryListItemService,
            IGroceryListService groceryListService,
            IProductCategoryService categoryService,
            IProductDiscountService discountService,
            IProductReviewService reviewService,
            IProductSubcategoryService subcategoryService,
            ISupplierService supplierService
            )
        {
            _productService = productService;
            _favouriteService = favouriteService;
            _groceryListItemService = groceryListItemService;
            _groceryListService = groceryListService;
            _categoryService = categoryService;
            _discountService = discountService;
            _reviewService = reviewService;
            _subcategoryService = subcategoryService;
            _supplierService = supplierService;
        }

        #region "Products"
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var _productList = await _productService.GetAll();

            Product _product;
            var _products = new List<Product>();

            foreach (var item in _productList)
            {
                _product = new Product()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Barcode = item.Barcode,
                    Price = item.Price,
                    HasDiscount = false,
                    DiscountPrice = item.Price,
                    Image = Image.Generate(item.ImageData, item.ImageType),
                    Features = item.Features,
                    Usage = item.Usage,
                    Slug = item.Slug,
                    ReviewsCount = item.Reviews.Count,
                    Reviews = null
                };

                _products.Add(_product);
            }

            return Ok(_products);
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var _product = await _productService.GetById(id);

            if (_product == null)
            {
                return NotFound();
            }

            var product = new Product()
            {
                Id = _product.Id,
                Title = _product.Title,
                Description = _product.Description,
                Barcode = _product.Barcode,
                Price = _product.Price,
                HasDiscount = false,
                DiscountPrice = _product.Price,
                Image = Image.Generate(_product.ImageData, _product.ImageType),
                Features = _product.Features,
                Usage = _product.Usage,
                Slug = _product.Slug,
                ReviewsCount = _product.Reviews.Count,
                Reviews = null,
            };

            return Ok(product);
        }

        // GET: api/Products/Slug/{string}
        [HttpGet("Slug/{slug}", Name = "GetProductBySlug")]
        public async Task<ActionResult<Product>> GetProductBySlug(string slug)
        {
            var _product = await _productService.GetBySlug(slug);

            if (_product == null)
            {
                return NotFound();
            }


            var product = new Product()
            {
                Id = _product.Id,
                Title = _product.Title,
                Description = _product.Description,
                Barcode = _product.Barcode,
                Price = _product.Price,
                HasDiscount = false,
                DiscountPrice = _product.Price,
                Image = Image.Generate(_product.ImageData, _product.ImageType),
                Features = _product.Features,
                Usage = _product.Usage,
                Slug = _product.Slug,
                ReviewsCount = _product.Reviews.Count,
                Reviews = null,
            };

            return Ok(product);
        }

        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Data.Models.Product product)
        {
            if (id != product.Id || product == null)
            {
                return BadRequest();
            }

            var _productExists = await _productService.GetById(id);
            if (_productExists == null)
            {
                return NotFound();
            }

            await _productService.Edit(product);

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Data.Models.Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            product.Slug = Slug.Generate(product.Title);

            await _productService.Create(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            await _productService.Remove(id);

            return NoContent();
        }
        #endregion

        #region "Products/Categories"
        // GET: api/Products/Categories
        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetProductCategories()
        {
            var categoryList = await _categoryService.GetAll();

            Category _category;
            var _categories = new List<Category>();

            foreach (var item in categoryList)
            {
                _category = new Category()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Image = Image.Generate(item.ImageData, item.ImageType),
                    Slug = item.Slug,
                    SubCategoryCount = item.ProductSubCategories.Count
                };

                _categories.Add(_category);
            }

            return Ok(_categories);
        }

        //GET: api/Products/Categories/{id}
        [HttpGet("Categories/{id}")]
        public async Task<ActionResult<Category>> GetProductCategory(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            var _category = new Category()
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                Image = Image.Generate(category.ImageData, category.ImageType),
                Slug = category.Slug,
                SubCategoryCount = category.ProductSubCategories.Count
            };

            return Ok(_category);
        }

        // GET: api/Products/Categories/Slug/{string}
        [HttpGet("Categories/Slug/{slug}", Name = "GetCategoryBySlug")]
        public async Task<ActionResult<Category>> GetCategoryBySlug(string slug)
        {
            var category = await _categoryService.GetBySlug(slug);

            if (category == null)
            {
                return NotFound();
            }

            var _category = new Category()
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                Image = Image.Generate(category.ImageData, category.ImageType),
                Slug = category.Slug,
                SubCategoryCount = category.ProductSubCategories.Count
            };

            return Ok(_category);
        }

        // PUT: api/Products/Categories/{id}
        [HttpPut("Categories/{id}")]
        public async Task<IActionResult> PutProductCategory(int id, Data.Models.ProductCategory category)
        {
            if (id != category.Id || category == null)
            {
                return BadRequest();
            }

            var _categoryExists = await _categoryService.GetById(id);
            if (_categoryExists == null)
            {
                return NotFound();
            }

            await _categoryService.Edit(category);

            return NoContent();
        }

        // POST: api/Products/Categories
        [HttpPost("Categories")]
        public async Task<ActionResult<Data.Models.ProductCategory>> PostCategory(Data.Models.ProductCategory category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            category.Slug = Slug.Generate(category.Title);

            await _categoryService.Create(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Products/Categories/{id}
        [HttpDelete("Categories/{id}")]
        public async Task<ActionResult<Data.Models.ProductCategory>> DeleteCategory(int id)
        {
            await _categoryService.Remove(id);

            return NoContent();
        }
        #endregion

        #region "Products/Subcategories"
        // GET: api/Products/SubCategories
        [HttpGet("SubCategories")]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategories()
        {
            var subcategoryList = await _subcategoryService.GetAll();

            SubCategory _subcategory;
            var _subcategories = new List<SubCategory>();

            foreach (var item in subcategoryList)
            {
                _subcategory = new SubCategory()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Image = Image.Generate(item.ImageData, item.ImageType),
                    Slug = item.Slug,
                    ProductsCount = 0
                };

                _subcategories.Add(_subcategory);
            }

            return Ok(_subcategories);
        }

        //// GET: api/Products/SubCategories/{id}
        [HttpGet("SubCategories/{id}", Name = "GetSubcategory")]
        public async Task<ActionResult<SubCategory>> GetProductSubCategory(int id)
        {
            var subcategory = await _subcategoryService.GetById(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            var _subcategory = new SubCategory()
            {
                Id = subcategory.Id,
                Title = subcategory.Title,
                Description = subcategory.Description,
                Image = Image.Generate(subcategory.ImageData, subcategory.ImageType),
                Slug = subcategory.Slug,
                ProductsCount = 0
            };

            return Ok(_subcategory);
        }

        // GET: api/Products/SubCategories/Slug/{string}
        [HttpGet("SubCategories/Slug/{slug}", Name = "GetSubcategoryBySlug")]
        public async Task<ActionResult<SubCategory>> GetSubCategoryBySlug(string slug)
        {
            var subcategory = await _subcategoryService.GetBySlug(slug);

            if (subcategory == null)
            {
                return NotFound();
            }

            var _subcategory = new SubCategory()
            {
                Id = subcategory.Id,
                Title = subcategory.Title,
                Description = subcategory.Description,
                Image = Image.Generate(subcategory.ImageData, subcategory.ImageType),
                Slug = subcategory.Slug,
                ProductsCount = 0
            };

            return Ok(_subcategory);
        }

        // GET: api/Products/SubCategories/CategoryId/{categoryId}
        [HttpGet("SubCategories/CategoryId/{categoryId}", Name = "GetSubCategoryByCategoryId")]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategoryByCategoryId(int categoryId)
        {

            var subcategoryList = await _subcategoryService.GetByCategoryId(categoryId);

            SubCategory _subcategory;
            var _subcategories = new List<SubCategory>();

            foreach (var item in subcategoryList)
            {
                _subcategory = new SubCategory()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Image = Image.Generate(item.ImageData, item.ImageType),
                    Slug = item.Slug,
                    ProductsCount = 0
                };

                _subcategories.Add(_subcategory);
            }

            return Ok(_subcategories);

            //ProductSubCategoryViewModel _subcategory;
            //var _subcategories = new List<ProductSubCategoryViewModel>();

            //var subcategories = await _subcategoryService.GetByCategoryId(categoryId);

            //if (subcategories == null)
            //{
            //    return NotFound();
            //}

            //foreach (var subcategory in subcategories)
            //{
            //    _subcategory = new ProductSubCategoryViewModel()
            //    {
            //        Id = subcategory.Id,
            //        Title = subcategory.Title,
            //        Description = subcategory.Description,
            //        Image = Image.Generate(subcategory.ImageData, subcategory.ImageType),
            //        Slug = subcategory.Slug
            //    };

            //    _subcategories.Add(_subcategory);
            //}

            //return Ok(_subcategories);
        }

        // PUT: api/Products/SubCategories/{id}
        [HttpPut("SubCategories/{id}")]
        public async Task<IActionResult> PutSubCategory(int id, Data.Models.ProductSubCategory subCategory)
        {
            if (id != subCategory.Id || subCategory == null)
            {
                return BadRequest();
            }

            var _subcategoryExists = await _subcategoryService.GetById(id);
            if (_subcategoryExists == null)
            {
                return NotFound();
            }

            await _subcategoryService.Edit(subCategory);

            return NoContent();
        }

        // POST: api/Products/SubCategories
        [HttpPost("SubCategories")]
        public async Task<ActionResult<Data.Models.ProductSubCategory>> PostSubCategory(Data.Models.ProductSubCategory subCategory)
        {
            if (subCategory == null)
            {
                return BadRequest();
            }

            subCategory.Slug = Slug.Generate(subCategory.Title);

            await _subcategoryService.Create(subCategory);

            return CreatedAtAction("GetSubcategory", new { id = subCategory.Id }, subCategory);
        }

        // DELETE: api/Products/SubCategories/{id}
        [HttpDelete("SubCategories/{id}")]
        public async Task<ActionResult<Data.Models.ProductSubCategory>> DeleteSubCategory(int id)
        {
            await _subcategoryService.Remove(id);

            return NoContent();
        }
        #endregion

        #region "Products/Favourites"
        // GET: api/Products/Favourites
        [HttpGet("Favourites")]
        public async Task<ActionResult<IEnumerable<Favourite>>> GetFavouriteProducts()
        {
            var _favouriteList = await _favouriteService.GetAll();

            Favourite _favourite;
            var _favourites = new List<Favourite>();

            foreach (var item in _favouriteList)
            {
                _favourite = new Favourite()
                {
                    Id = item.Id,
                    ProductTitle = item.Product.Title,
                    ProductSlug = item.Product.Slug,
                    ProductImage = Image.Generate(item.Product.ImageData, item.Product.ImageType)
                };

                _favourites.Add(_favourite);
            }

            return Ok(_favourites);
        }

        // GET: api/Products/Favourites/{id}
        [HttpGet("Favourites/{id}", Name = "GetFavourite")]
        public async Task<ActionResult<Favourite>> GetFavouriteProduct(int id)
        {
            var favourite = await _favouriteService.GetById(id);

            if (favourite == null)
            {
                return NotFound();
            }

            var _favourite = new Favourite()
            {
                Id = favourite.Id,
                ProductTitle = favourite.Product.Title,
                ProductSlug = favourite.Product.Slug,
                ProductImage = Image.Generate(favourite.Product.ImageData, favourite.Product.ImageType)
            };

            return Ok(_favourite);
        }

        // GET: api/Products/Favourites/UserId
        [Authorize]
        [HttpGet("Favourites/UserId", Name = "GetFavouritesByUserId")]
        public async Task<ActionResult<IEnumerable<Favourite>>> GetFavouritesByUserId()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var _favouriteList = await _favouriteService.GetByUserId(userId);

            Favourite _favourite;
            var _favourites = new List<Favourite>();

            foreach (var item in _favouriteList)
            {
                _favourite = new Favourite()
                {
                    Id = item.Id,
                    ProductTitle = item.Product.Title,
                    ProductSlug = item.Product.Slug,
                    ProductImage = Image.Generate(item.Product.ImageData, item.Product.ImageType)
                };

                _favourites.Add(_favourite);
            }

            return Ok(_favourites);
        }

        // POST: api/Products/Favourites
        [HttpPost("Favourites")]
        public async Task<ActionResult<Data.Models.FavouriteProduct>> PostFavouriteProduct(Data.Models.FavouriteProduct favourite)
        {
            if (favourite == null)
            {
                return BadRequest();
            }

            await _favouriteService.Create(favourite);

            return CreatedAtAction("GetFavouriteProduct", new { id = favourite.Id }, favourite);
        }

        // DELETE: api/Products/Favourites/{id}
        [HttpDelete("Favourites/{id}")]
        public async Task<ActionResult<Data.Models.FavouriteProduct>> DeleteFavouriteProduct(int id)
        {
            await _favouriteService.Remove(id);

            return NoContent();
        }
        #endregion

        #region "Products/Discounts"
        //// GET: api/Products/Discounts
        //[HttpGet("Discounts")]
        //public async Task<ActionResult<IEnumerable<ProductDiscountViewModel>>> GetProductDiscounts()
        //{
        //    ProductDiscountViewModel _discount;
        //    var _discounts = new List<ProductDiscountViewModel>();

        //    var discounts = await _discountService.GetAll();

        //    foreach (var discount in discounts)
        //    {
        //        _discount = new ProductDiscountViewModel()
        //        {
        //            Id = discount.Id,
        //            Title = discount.Title,
        //            Percentage = discount.Percentage,
        //            StartDate = discount.StartDate,
        //            EndDate = discount.EndDate,
        //            Product = discount.Product
        //        };

        //        _discounts.Add(_discount);
        //    }

        //    return Ok(_discounts);
        //}

        //// GET: api/Products/Discounts/{id}
        //[HttpGet("Discounts/{id}", Name = "GetDiscount")]
        //public async Task<ActionResult<ProductDiscount>> GetProductDiscount(int id)
        //{
        //    var discount = await _discountService.GetById(id);

        //    if (discount == null)
        //    {
        //        return NotFound();
        //    }
        //    var _discount = new ProductDiscountViewModel()
        //    {
        //        Id = discount.Id,
        //        Title = discount.Title,
        //        Percentage = discount.Percentage,
        //        StartDate = discount.StartDate,
        //        EndDate = discount.EndDate,
        //        Product = discount.Product
        //    };
        //    return Ok(_discount);
        //}

        //// GET: api/Products/Discounts/ProductId/{productId}
        //[HttpGet("Discounts/ProductId/{Id}", Name = "GetDiscountByProductId")]
        //public async Task<ActionResult<IEnumerable<ProductDiscount>>> GetDiscountByProductId(int productId)
        //{
        //    ProductDiscountViewModel _discount;
        //    var _discounts = new List<ProductDiscountViewModel>();

        //    var discounts = await _discountService.GetByProductId(productId);

        //    if (discounts == null)
        //    {
        //        return NotFound();
        //    }

        //    foreach (var discount in discounts)
        //    {
        //        _discount = new ProductDiscountViewModel()
        //        {
        //            Id = discount.Id,
        //            Title = discount.Title,
        //            Percentage = discount.Percentage,
        //            StartDate = discount.StartDate,
        //            EndDate = discount.EndDate,
        //            Product = discount.Product
        //        };

        //        _discounts.Add(_discount);
        //    }

        //    return Ok(_discounts);
        //}

        //// GET: api/Products/Discounts/Date/Today
        //[HttpGet("Discounts/Date/Today", Name = "GetDiscountsToday")]
        //public async Task<ActionResult<IEnumerable<ProductDiscount>>> GetDiscountToday()
        //{
        //    ProductDiscountViewModel _discount;
        //    var _discounts = new List<ProductDiscountViewModel>();

        //    var discounts = await _discountService.GetByDate(DateTime.Now);

        //    if (discounts == null)
        //    {
        //        return NotFound();
        //    }

        //    foreach (var discount in discounts)
        //    {
        //        _discount = new ProductDiscountViewModel()
        //        {
        //            Id = discount.Id,
        //            Title = discount.Title,
        //            Percentage = discount.Percentage,
        //            StartDate = discount.StartDate,
        //            EndDate = discount.EndDate,
        //            Product = discount.Product
        //        };

        //        _discounts.Add(_discount);
        //    }

        //    return Ok(_discounts);
        //}

        //// PUT: api/Products/Discounts/{id}
        //[HttpPut("Discounts/{id}")]
        //public async Task<IActionResult> PutProductDiscount(int id, ProductDiscount discount)
        //{
        //    if (id != discount.Id || discount == null)
        //    {
        //        return BadRequest();
        //    }

        //    var _discountExists = await _discountService.GetById(id);
        //    if (_discountExists == null)
        //    {
        //        return NotFound();
        //    }

        //    await _discountService.Edit(discount);

        //    return NoContent();
        //}

        //// POST: api/Products/Discounts
        //[HttpPost("Discounts")]
        //public async Task<ActionResult<ProductDiscount>> PostProductDiscount(ProductDiscount discount)
        //{
        //    if (discount == null)
        //    {
        //        return BadRequest();
        //    }

        //    await _discountService.Create(discount);

        //    return CreatedAtAction("GetProductDiscount", new { id = discount.Id }, discount);
        //}

        //// DELETE: api/Products/Discounts/{id}
        //[HttpDelete("Discounts/{id}")]
        //public async Task<ActionResult<ProductDiscount>> DeleteProductDiscount(int id)
        //{
        //    await _discountService.Remove(id);

        //    return NoContent();
        //}
        #endregion

        #region "Products/Supplier"
        // GET: api/Products/Supplier
        [HttpGet("Suppliers")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var _supplierList = await _supplierService.GetAll();

            Supplier _supplier;
            var _suppliers = new List<Supplier>();

            foreach (var item in _supplierList)
            {
                _supplier = new Supplier()
                {
                    Id = item.Id,
                    CompanyName = item.CompanyName,
                    ContactName = item.ContactName,
                    ContactTitle = item.ContactTitle,
                    Address = item.Address,
                    City = item.City,
                    Province = item.Province,
                    EmailAddress = item.EmailAddress,
                    PhoneNumber = item.PhoneNumber,
                    FaxNumber = item.FaxNumber,
                    HomePage = item.HomePage,
                    Slug = item.Slug,
                    ProductsCount = item.Products.Count
                };

                _suppliers.Add(_supplier);
            }

            return Ok(_suppliers);
        }

        // GET: api/Products/Supplier/{id}
        [HttpGet("Suppliers/{id}", Name = "GetSupplier")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            var _supplier = new Supplier()
            {
                Id = supplier.Id,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Province = supplier.Province,
                EmailAddress = supplier.EmailAddress,
                PhoneNumber = supplier.PhoneNumber,
                FaxNumber = supplier.FaxNumber,
                HomePage = supplier.HomePage,
                Slug = supplier.Slug,
                ProductsCount = supplier.Products.Count
            };

            return Ok(_supplier);
        }

        // GET: api/Products/Supplier/Slug/{string}
        [HttpGet("Suppliers/Slug/{slug}", Name = "GetSupplierBySlug")]
        public async Task<ActionResult<Supplier>> GetSupplierBySlug(string slug)
        {
            var supplier = await _supplierService.GetBySlug(slug);

            if (supplier == null)
            {
                return NotFound();
            }

            var _supplier = new Supplier()
            {
                Id = supplier.Id,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Province = supplier.Province,
                EmailAddress = supplier.EmailAddress,
                PhoneNumber = supplier.PhoneNumber,
                FaxNumber = supplier.FaxNumber,
                HomePage = supplier.HomePage,
                Slug = supplier.Slug,
                ProductsCount = supplier.Products.Count
            };

            return Ok(_supplier);
        }

        // PUT: api/Products/Supplier/{id}
        [HttpPut("Suppliers/{id}")]
        public async Task<IActionResult> PutSupplier(int id, Data.Models.Supplier supplier)
        {
            if (id != supplier.Id || supplier == null)
            {
                return BadRequest();
            }

            var _supplierExists = await _supplierService.GetById(id);
            if (_supplierExists == null)
            {
                return NotFound();
            }

            await _supplierService.Edit(supplier);

            return NoContent();
        }

        // POST: api/Products/Supplier
        [HttpPost("Suppliers")]
        public async Task<ActionResult<Data.Models.Supplier>> PostSupplier(Data.Models.Supplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest();
            }

            supplier.Slug = Slug.Generate(supplier.CompanyName);

            await _supplierService.Create(supplier);

            return CreatedAtAction("GetSupplier", new { id = supplier.Id }, supplier);
        }

        // DELETE: api/Products/Supplier/{id}
        [HttpDelete("Suppliers/{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            await _supplierService.Remove(id);

            return NoContent();
        }
        #endregion

        #region "Products/Lists"
        // GET: api/Products/Lists
        [HttpGet("Lists")]
        public async Task<ActionResult<IEnumerable<GroceryList>>> GetGroceryLists()
        {
            var lists = await _groceryListService.GetAll();

            GroceryList _list;
            var _lists = new List<GroceryList>();

            foreach (var item in lists)
            {
                _list = new GroceryList()
                {
                    Id = item.Id,
                    Title = item.Title,
                    DateCreated = item.DateCreated,
                    GroceryListItemsCount = item.GroceryListItems.Count
                };

                _lists.Add(_list);
            }

            return Ok(_lists);
        }

        // GET: api/Products/Lists/{id}
        [HttpGet("Lists/{id}")]
        public async Task<ActionResult<GroceryList>> GetGroceryList(int id)
        {
            var list = await _groceryListService.GetById(id);

            if (list == null)
            {
                return NotFound();
            }

            var _list = new GroceryList()
            {
                Id = list.Id,
                Title = list.Title,
                DateCreated = list.DateCreated,
                GroceryListItemsCount = list.GroceryListItems.Count
            };

            return Ok(_list);
        }

        // GET: api/Products/Lists/UserId
        [Authorize]
        [HttpGet("Lists/UserId", Name = "GetGroceryListByUserId")]
        public async Task<ActionResult<IEnumerable<GroceryList>>> GetGroceryListByUserId()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var lists = await _groceryListService.GetByUserId(userId);

            GroceryList _list;
            var _lists = new List<GroceryList>();

            foreach (var item in lists)
            {
                _list = new GroceryList()
                {
                    Id = item.Id,
                    Title = item.Title,
                    DateCreated = item.DateCreated,
                    GroceryListItemsCount = item.GroceryListItems.Count
                };

                _lists.Add(_list);
            }

            return Ok(_lists);
        }

        // PUT: api/Products/Lists/{id}
        [HttpPut("Lists/{id}")]
        public async Task<IActionResult> PutGroceryList(int id, Data.Models.GroceryList groceryList)
        {
            if (id != groceryList.Id || groceryList == null)
            {
                return BadRequest();
            }

            var _groceryListExists = await _groceryListService.GetById(id);
            if (_groceryListExists == null)
            {
                return NotFound();
            }

            await _groceryListService.Edit(groceryList);

            return NoContent();
        }

        // POST: api/Products/Lists
        [HttpPost("Lists")]
        public async Task<ActionResult<Data.Models.GroceryList>> PostGroceryList(Data.Models.GroceryList groceryList)
        {
            if (groceryList == null)
            {
                return BadRequest();
            }

            await _groceryListService.Create(groceryList);

            return CreatedAtAction("GetGroceryList", new { id = groceryList.Id }, groceryList);
        }

        // DELETE: api/Products/Lists/{id}
        [HttpDelete("Lists/{id}")]
        public async Task<ActionResult<Data.Models.GroceryList>> DeleteGroceryList(int id)
        {
            await _groceryListService.Remove(id);

            return NoContent();
        }
        #endregion

        #region "Products/List/Items"
        // GET: api/Products/List/Items
        [HttpGet("List/Items")]
        public async Task<ActionResult<IEnumerable<GroceryListItem>>> GetGroceryListItems()
        {
            var listItems = await _groceryListItemService.GetAll();

            GroceryListItem _listItem;
            var _listItems = new List<GroceryListItem>();

            foreach (var item in listItems)
            {
                _listItem = new GroceryListItem()
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    DateCreated = item.DateCreated,
                    ProductTitle = item.Product.Title,
                    ProductSlug = item.Product.Slug,
                    ProductImage = Image.Generate(item.Product.ImageData, item.Product.ImageType)
                };

                _listItems.Add(_listItem);
            }

            return Ok(_listItems);
        }

        // GET: api/Products/List/Items/{id}
        [HttpGet("List/Items/{id}")]
        public async Task<ActionResult<GroceryListItem>> GetGroceryListItem(int id)
        {
            var listItem = await _groceryListItemService.GetById(id);

            if (listItem == null)
            {
                return NotFound();
            }

            var _listItem = new GroceryListItem()
            {
                Id = listItem.Id,
                Quantity = listItem.Quantity,
                DateCreated = listItem.DateCreated,
                ProductTitle = listItem.Product.Title,
                ProductSlug = listItem.Product.Slug,
                ProductImage = Image.Generate(listItem.Product.ImageData, listItem.Product.ImageType)
            };

            return Ok(_listItem);
        }

        // GET: api/Products/List/Items/ListId/{groceryListId}
        [HttpGet("List/Items/ListId/{groceryListId}")]
        public async Task<ActionResult<IEnumerable<GroceryListItem>>> GetGroceryListItemByGroceryListId(int groceryListId)
        {
            var listItems = await _groceryListItemService.GetByGroceryListId(groceryListId);

            GroceryListItem _listItem;
            var _listItems = new List<GroceryListItem>();

            foreach (var item in listItems)
            {
                _listItem = new GroceryListItem()
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    DateCreated = item.DateCreated,
                    ProductTitle = item.Product.Title,
                    ProductSlug = item.Product.Slug,
                    ProductImage = Image.Generate(item.Product.ImageData, item.Product.ImageType)
                };

                _listItems.Add(_listItem);
            }

            return Ok(_listItems);
        }

        // PUT: api/Products/List/Items/{id}
        [HttpPut("List/Items/{id}")]
        public async Task<IActionResult> PutGroceryListItem(int id, Data.Models.GroceryListItem groceryListItem)
        {
            if (id != groceryListItem.Id || groceryListItem == null)
            {
                return BadRequest();
            }

            var _supplierExists = await _groceryListItemService.GetById(id);
            if (_supplierExists == null)
            {
                return NotFound();
            }

            await _groceryListItemService.Edit(groceryListItem);

            return NoContent();
        }

        // POST: api/Products/List/Items
        [HttpPost("List/Items")]
        public async Task<ActionResult<Data.Models.GroceryListItem>> PostGroceryListItem(Data.Models.GroceryListItem groceryListItem)
        {
            if (groceryListItem == null)
            {
                return BadRequest();
            }

            await _groceryListItemService.Create(groceryListItem);

            return CreatedAtAction("GetGroceryListItem", new { id = groceryListItem.Id }, groceryListItem);
        }

        // DELETE: api/Products/List/Items/{id}
        [HttpDelete("List/Items/{id}")]
        public async Task<ActionResult<Data.Models.GroceryListItem>> DeleteGroceryListItem(int id)
        {
            await _groceryListItemService.Remove(id);

            return NoContent();
        }
        #endregion
    }
}
