using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreApp.Domain.Entities;


namespace StoreApp.Persistance.Context
{
    public class DbInitializer
    {
        
        public static async Task InitDb(StoreAppDbContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() && !context.Categories.Any() && !context.Brands.Any() && !context.Products.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Name = "test",
                        UserName = "test",
                        Email = "test@test.com"
                    },
                    new AppUser
                    {
                        Name = "test2",
                        UserName = "test2",
                        Email = "test2@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "123");
                }

                var categories = new List<Category>
                {
                    new Category
                    {
                        CategoryName = "Bilgisayar",
                    },
                    new Category
                    {
                        CategoryName = "Dizüstü Bilgisayar",
                    },
                    new Category
                    {
                        CategoryName = "Tablet",
                    },
                    new Category
                    {
                        CategoryName = "Telefon",
                    },
                   
                    new Category
                    {
                        CategoryName = "Beyaz Eşya",
                    },
                    new Category
                    {
                        CategoryName = "Televizyon",
                    },
                };

                await context.Categories.AddRangeAsync(categories);


                var brands = new List<Brand>
                {
                    new Brand
                    {
                        BrandName = "Brand1",
                    },
                    new Brand
                    {
                        BrandName = "Brand2",
                    },
                    new Brand
                    {
                       BrandName = "Brand3",
                    },
                    new Brand
                    {
                        BrandName = "Brand4",
                    },
                    new Brand
                    {
                        BrandName = "Brand5",
                    },
                    new Brand
                    {
                        BrandName = "Brand6",
                    }
                };

                await context.Brands.AddRangeAsync(brands);


                var products = new List<Product>
                {
                    new Product
                    {
                        Name ="Product - 1",
                        Brand = brands[0],
                        Categories = [categories[0], categories[1],categories[2]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 129000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786407/new-laptop-balancing-with-water_ssk5te.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 2",
                        Brand = brands[1],
                        Categories = [categories[0], categories[1]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 149000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786276/electronic-device-balancing-concept_zczblk.jpg"
                    },
                    new Product
                    {
                     
                        Name ="Product - 3",
                        Brand = brands[2],
                        Categories = [categories[3]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 80000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786634/P6YSG40_vdrjxv.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 4",
                        Brand = brands[3],
                        Categories = [categories[3]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 70000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786951/OW9BOF0_wmvgvh.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 5",
                        Brand = brands[4],
                        Categories = [categories[5]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 65000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708787075/O9FG5V0_on81ex.jpg"
                    },

                    new Product
                    {
                        Name ="Product - 6",
                        Brand = brands[0],
                        Categories = [categories[0]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 129000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786407/new-laptop-balancing-with-water_ssk5te.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 7",
                        Brand = brands[1],
                        Categories = [categories[0], categories[1]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 149000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786276/electronic-device-balancing-concept_zczblk.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 8",
                        Brand = brands[2],
                        Categories = [categories[3]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 80000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786634/P6YSG40_vdrjxv.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 9",
                        Brand = brands[3],
                        Categories = [categories[3]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 70000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786951/OW9BOF0_wmvgvh.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 10",
                        Brand = brands[4],
                        Categories = [categories[5]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 65000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708787075/O9FG5V0_on81ex.jpg"
                    },

                    new Product
                    {
                        Name ="Product - 11",
                        Brand = brands[0],
                        Categories = [categories[0], categories[1],categories[2]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 129000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786407/new-laptop-balancing-with-water_ssk5te.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 12",
                        Brand = brands[1],
                        Categories = [categories[0], categories[1]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 149000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786276/electronic-device-balancing-concept_zczblk.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 13",
                        Brand = brands[2],
                        Categories = [categories[3]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 80000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786634/P6YSG40_vdrjxv.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 14",
                        Brand = brands[3],
                        Categories = [categories[3]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 70000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708786951/OW9BOF0_wmvgvh.jpg"
                    },
                    new Product
                    {
                        Name ="Product - 15",
                        Brand = brands[4],
                        Categories = [categories[5]],
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna",
                        Price = 65000,
                        PictureUrl ="https://res.cloudinary.com/df3zonw5u/image/upload/v1708787075/O9FG5V0_on81ex.jpg"
                    },

                };

                await context.Products.AddRangeAsync(products);

                await context.SaveChangesAsync();

            }
        }
    }
}
