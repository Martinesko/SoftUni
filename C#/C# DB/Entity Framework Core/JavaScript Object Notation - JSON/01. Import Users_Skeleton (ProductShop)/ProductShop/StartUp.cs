using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Security.Cryptography.X509Certificates;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            Console.WriteLine(GetProductsInRange(context));
        }
        //Import
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            var users = mapper.Map<User[]>(userDtos);

            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var ProductDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            var Products = mapper.Map<Product[]>(ProductDtos);
            
            context.Products.AddRange(Products);
            context.SaveChanges();
            return $"Successfully imported {Products.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var mapper = CreateMapper();
            var categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            var categories = new HashSet<Category>();
            foreach (var item in categoryDtos)
            {
                if (item.Name != null)
                {
                    categories.Add(mapper.Map<Category>(item));
                }
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);
            var categoryProducts = new HashSet<CategoryProduct>();
            foreach (var item in categoryProductDtos)
            {
                CategoryProduct cp = mapper.Map<CategoryProduct>(item);
                categoryProducts.Add(cp);
            }

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); }));
        }

        //Export
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(p => p.Price>=500 && p.Price<=1000).OrderBy(p => p.Price).Select(p => new { name = p.Name,price=p.Price,seller=p.Seller.FirstName + " "+p.Seller.LastName }).AsNoTracking().ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}