using DropShippingWebStore_Signature.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingWebStore_Signature.Domain.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        private int _discount;
        public int Discount
        {
            get => _discount;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Discount), "Discount must be between 0 and 100.");
                _discount = value;
            }
        }
        public decimal DiscountPrice => OnSale ? Price * (1 - Discount / 100m) : Price;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }

}
