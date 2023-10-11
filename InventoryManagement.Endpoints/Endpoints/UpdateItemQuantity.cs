using InventoryManagement.Application.Contracts.Features;
using InventoryManagement.Application.Dtos.Items;
using InventoryManagement.Application.Features;
using InventoryManagement.Infrastructure.Queue.Contracts;
using InventoryManagment.Endpoints.Dtos.RequestDtos;
using InventoryManagment.Endpoints.Dtos.ResponseDtos;
using InventoryManagement.Infrastructure.Dtos.MailDto;

namespace InventoryManagment.Endpoints.Endpoints
{
    public class UpdateItemQuantity: Endpoint<UpdateItemQuantityRequest, BaseResponse>
    {
        public IUpdateQuantity _updateQuantityFeature;
        public IMessageQueueService _messageQueueService;
        public UpdateItemQuantity(IUpdateQuantity updateQuanity, IMessageQueueService messageQueueService)
        {
            _updateQuantityFeature = updateQuanity;
            _messageQueueService = messageQueueService;
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

            // if (dto.InOut)
            //     await _updateQuantityFeature.AddItemQuantity(updateDto);
            // else 
            //     await _updateQuantityFeature.SubtractItemQuantity(updateDto);

            _messageQueueService.SendMessage(new MailDto 
            {
                Addresses = new List<string>{
                    "lujamaharjan7@gmail.com"
                },
                Subject = "",
                MailBody=""
            });
            await SendAsync(new()
            {
                Status = true,
                Message = "Item Quantity Updated Succesfully"
            });
            
        }
    }
}
