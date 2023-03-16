using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            
           //Console.WriteLine(ImportCategoryProducts(context, inputJson));
            Console.WriteLine(GetUsersWithProducts(context));           
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
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count>=1 || u.ProductsSold.FirstOrDefault(ps=>ps.Buyer != null) != null)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(u =>new { firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Where(ps=>ps.Buyer != null).Select(ps => 
                    new { name = ps.Name, price = ps.Price, buyerFirstName = ps.Buyer.FirstName, buyerLastName = ps.Buyer.LastName
                    }
                    )
                })
                .ToArray();
            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.
            OrderByDescending(c => c.CategoriesProducts.Count)
            .Select(c => new
            {
                category = c.Name,
                productsCount = c.CategoriesProducts.Count,
                averagePrice = (c.CategoriesProducts.Any() ? c.CategoriesProducts.Average(cp => cp.Product.Price) : 0).ToString("f2"),
                totalRevenue = (c.CategoriesProducts.Any() ? c.CategoriesProducts.Sum(cp => cp.Product.Price) : 0).ToString("f2")
            }).AsNoTracking().ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                        .Count(p => p.Buyer != null),
                        products = u.ProductsSold
                        .Where(p => p.Buyer!= null)
                        .Select(p => new {
                            name = p.Name, 
                            price = p.Price
                        })
                        .ToArray()}

                })
                .OrderByDescending(u => u.soldProducts.count)
                .AsNoTracking()
                .ToArray();

            var usersWrapper = new
            {
                usersCount = users.Length,
                users = users
            };
            return JsonConvert.SerializeObject(usersWrapper, Formatting.Indented,new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}