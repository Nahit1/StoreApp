using System;

namespace StoreApp.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
        public string Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }


        public ICollection<Category> Categories { get; set; }
    }
}
