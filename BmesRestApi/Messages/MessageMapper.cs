using System.Collections.Generic;
using BmesRestApi.Messages.DataTransferObjects.Address;
using BmesRestApi.Messages.DataTransferObjects.Cart;
using BmesRestApi.Messages.DataTransferObjects.Product;
using BmesRestApi.Models.Address;
using BmesRestApi.Models.Cart;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Messages
{
    public class MessageMapper
    {
        public Brand MapToBrand(BrandDto brandDto)
        {
            var brand = new Brand
            {
                Id = brandDto.Id,
                Name = brandDto.Name,
                Slug = brandDto.Slug,
                Description = brandDto.Description,
                MetaDescription = brandDto.MetaDescription,
                MetaKeywords = brandDto.MetaKeywords,
                BrandStatus = (BrandStatus)brandDto.BrandStatus,
                ModifiedDate = brandDto.ModifiedDate,
                IsDeleted = brandDto.IsDeleted
            };

            return brand;
        }

        public BrandDto MapToBrandDto(Brand brand)
        {
            var brandDto = new BrandDto();

            if (brand != null)
            {
                brandDto.Id = brand.Id;
                brandDto.Name = brand.Name;
                brandDto.Slug = brand.Slug;
                brandDto.Description = brand.Description;
                brandDto.MetaDescription = brand.MetaDescription;
                brandDto.MetaKeywords = brand.MetaKeywords;
                brandDto.BrandStatus = (int) brand.BrandStatus;
                brandDto.ModifiedDate = brand.ModifiedDate;
                brandDto.IsDeleted = brand.IsDeleted;
            }

            return brandDto;
        }

        public Category MapToCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Slug = categoryDto.Slug,
                Description = categoryDto.Description,
                MetaDescription = categoryDto.MetaDescription,
                MetaKeywords = categoryDto.MetaKeywords,
                CategoryStatus = (CategoryStatus)categoryDto.CategoryStatus,
                ModifiedDate = categoryDto.ModifiedDate,
                IsDeleted = categoryDto.IsDeleted
            };

            return category;
        }

        public CategoryDto MapToCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                MetaDescription = category.MetaDescription,
                MetaKeywords = category.MetaKeywords,
                CategoryStatus = (int)category.CategoryStatus,
                ModifiedDate = category.ModifiedDate,
                IsDeleted = category.IsDeleted
            };
        }

        public Product MapToProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Slug = productDto.Slug,
                Description = productDto.Description,
                MetaDescription = productDto.MetaDescription,
                MetaKeywords = productDto.MetaKeywords,
                SKU = productDto.MetaDescription,
                Model = productDto.MetaKeywords,
                Price = productDto.Price,
                SalePrice = productDto.SalePrice,
                OldPrice = productDto.OldPrice,
                ImageUrl = productDto.ImageUrl,
                QuantityInStock = productDto.QuantityInStock,
                IsBestseller = productDto.IsBestseller,
                CategoryId = productDto.CategoryId,
                BrandId = productDto.BrandId,
                ProductStatus = (ProductStatus)productDto.ProductStatus,
                CreateDate = productDto.CreateDate,
                ModifiedDate = productDto.ModifiedDate,
                IsDeleted = productDto.IsDeleted
            };

            return product;
        }

        public ProductDto MapToProductDto(Product product)
        {
            var productDto = new ProductDto();

            if(product != null)
            {
                productDto.Id = product.Id;
                productDto.Name = product.Name;
                productDto.Slug = product.Slug;
                productDto.Description = product.Description;
                productDto.MetaDescription = product.MetaDescription;
                productDto.MetaKeywords = product.MetaKeywords;
                productDto.SKU = product.MetaDescription;
                productDto.Model = product.MetaKeywords;
                productDto.Price = product.Price;
                productDto.SalePrice = product.SalePrice;
                productDto.OldPrice = product.OldPrice;
                productDto.ImageUrl = product.ImageUrl;
                productDto.QuantityInStock = product.QuantityInStock;
                productDto.IsBestseller = product.IsBestseller;
                productDto.CategoryId = product.CategoryId;
                productDto.BrandId = product.BrandId;
                productDto.ProductStatus = (int) product.ProductStatus;
                productDto.CreateDate = product.CreateDate;
                productDto.ModifiedDate = product.ModifiedDate;
                productDto.IsDeleted = product.IsDeleted;
            };

            return productDto;
        }

        public CartDto MapToCartDto(Cart cart)
        {
            var cartDto = new CartDto();
            if (cart != null)
            {
                cartDto.Id = cart.Id;
                cartDto.UniqueCartId = cart.UniqueCartId;
                cartDto.CartStatus = (int)cart.CartStatus;
                cartDto.CreateDate = cart.CreateDate;
                cartDto.ModifiedDate = cart.ModifiedDate;
                cartDto.IsDeleted = cart.IsDeleted;
            }
            return cartDto;
        }

        public Cart MapToCart(CartDto cartDto)
        {
            var cart = new Cart();

            if (cartDto != null)
            {
                cart.Id = cartDto.Id;
                cart.UniqueCartId = cartDto.UniqueCartId;
                cart.CartStatus = (CartStatus) cartDto.CartStatus;
                cart.CreateDate = cartDto.CreateDate;
                cart.ModifiedDate = cartDto.ModifiedDate;
                cart.IsDeleted = cartDto.IsDeleted;
            };

            return cart;
        }

        public CartItemDto MapToCartItemDto(CartItem cartItem)
        {
            CartItemDto cartItemDto = null;

            if (cartItem.Product != null)
            {
                var productDto = MapToProductDto(cartItem.Product);

                cartItemDto = new CartItemDto
                {
                    Id = cartItem.Id,
                    CartId = cartItem.CartId,
                    Product = productDto,
                    Quantity = cartItem.Quantity 
                };
            }

            return cartItemDto;
        }

        public CartItem MapToCartItem(CartItemDto cartItemDto)
        {
            return new CartItem
            {
                CartId = cartItemDto.CartId,
                ProductId = cartItemDto.Product.Id,
                Quantity = cartItemDto.Quantity
            };
        }

        public AddressDto MapToAddressDto(Address address)
        {
            var addressDto = new AddressDto();

            if(address != null)
            {
                addressDto.Id = address.Id;
                addressDto.Name = address.Name;
                addressDto.AddressLine1 = address.AddressLine1;
                addressDto.AddressLine2 = address.AddressLine2;
                addressDto.City = address.City;
                addressDto.Country = address.Country;
                addressDto.State = address.State;
                addressDto.ZipCode = address.ZipCode;
                addressDto.CreateDate = address.CreateDate;
                addressDto.ModifiedDate = address.ModifiedDate;
                addressDto.IsDeleted = address.IsDeleted;

            };

            return addressDto;
        }

        public Address MapToAddress(AddressDto addressDto)
        {
            var address = new Address();
            if(addressDto != null)
            {
                address.Id = addressDto.Id;
                address.Name = addressDto.Name;
                address.AddressLine1 = addressDto.AddressLine1;
                address.AddressLine2 = addressDto.AddressLine2;
                address.City = addressDto.City;
                address.Country = addressDto.Country;
                address.State = addressDto.State;
                address.ZipCode = addressDto.ZipCode;
                address.CreateDate = addressDto.CreateDate;
                address.ModifiedDate = addressDto.ModifiedDate;
                address.IsDeleted = addressDto.IsDeleted;
            };
            return address;
        }

        public List<BrandDto> MapToBrandDtos(IEnumerable<Brand> brands)
        {
            var brandDtos = new List<BrandDto>();
            foreach (var brand in brands)
            {
                var brandDto = MapToBrandDto(brand);
                brandDtos.Add(brandDto);
            }
            return brandDtos;
        }

        public List<CategoryDto> MapToCategoryDtos(IEnumerable<Category> categories)
        {
            var categoryDtos = new List<CategoryDto>();
            foreach (var category in categories)
            {
                var categoryDto = MapToCategoryDto(category);
                categoryDtos.Add(categoryDto);
            }
            return categoryDtos;
        }

        public List<ProductDto> MapToProductDtos(IEnumerable<Product> products)
        {
            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                var productDto = MapToProductDto(product);
                productDtos.Add(productDto);
            }
            return productDtos;
        }

        public List<CartItemDto> MapToCartItemDtos(IEnumerable<CartItem> cartItems)
        {
            var cartItemDtos = new List<CartItemDto>();
            foreach (var cartItem in cartItems)
            {
                var cartItemDto = MapToCartItemDto(cartItem);
                cartItemDtos.Add(cartItemDto);
            }
            return cartItemDtos;
        }
        public List<AddressDto> MapToAddressDtos(IEnumerable<Address> addresses)
        {
            var addressDtos = new List<AddressDto>();
            foreach (var address in addresses)
            {
                var addressDto = MapToAddressDto(address);
                addressDtos.Add(addressDto);
            }
            return addressDtos;
        }
    }
}
