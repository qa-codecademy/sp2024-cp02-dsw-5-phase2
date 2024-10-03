namespace DropShippingWebStore_Signature.Domain.Domain
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
