namespace InventoryManagment.Endpoints.Dtos.RequestDtos
{
    public class UpdateItemQuantityRequest
    {
        public Guid ItemId { get; set; }
        public int ChangedQuantity { get; set; }
        public bool InOut { get; set; } 
    }
}
