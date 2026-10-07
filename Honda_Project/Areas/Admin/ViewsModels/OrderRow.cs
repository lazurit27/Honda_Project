using Honda_Project.Enums;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class OrderRow
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public int ProductId { get; set; }
    }
}
