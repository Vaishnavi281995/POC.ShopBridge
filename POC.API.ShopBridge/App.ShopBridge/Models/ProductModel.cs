using Microsoft.AspNetCore.Mvc;

namespace App.ShopBridge.Models
{
    public class ProductModel: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
