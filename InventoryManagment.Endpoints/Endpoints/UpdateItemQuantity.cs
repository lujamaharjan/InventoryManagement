using InventoryManagement.Application.Contracts.Features;
using InventoryManagement.Application.Dtos.Items;
using InventoryManagement.Application.Features;
using InventoryManagment.Endpoints.Dtos.RequestDtos;
using InventoryManagment.Endpoints.Dtos.ResponseDtos;

namespace InventoryManagment.Endpoints.Endpoints
{
    public class UpdateItemQuantity: Endpoint<UpdateItemQuantityRequest, BaseResponse>
    {
        public IUpdateQuantity _updateQuantityFeature;
        public UpdateItemQuantity(IUpdateQuantity updateQuanity)
        {
            _updateQuantityFeature = updateQuanity;
        }
        public override void Configure()
        {
            Get("/api/update-quantity");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateItemQuantityRequest dto, CancellationToken ct)
        {
            var updateDto = new UpdateItemQuantityDto()
            {
                ItemId = dto.ItemId,
                ChangedQuantity = dto.ChangedQuantity
            };

            if (dto.InOut)
                await _updateQuantityFeature.AddItemQuantity(updateDto);
            else 
                await _updateQuantityFeature.SubtractItemQuantity(updateDto);

            await SendAsync(new()
            {
                Status = true,
                Message = "Item Quantity Updated Succesfully"
            });
            
        }
    }
}
