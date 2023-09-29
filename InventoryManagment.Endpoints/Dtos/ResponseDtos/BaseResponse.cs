namespace InventoryManagment.Endpoints.Dtos.ResponseDtos
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Result { get; set; }
    }
}
