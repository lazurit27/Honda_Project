using Honda_Project.Enums;

namespace Honda_Project.Areas.Admin.ViewsModels
{
    public class OrderEdit
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

    }
}
