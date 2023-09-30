using InventoryManagement.Application.Contracts.Features;
using InventoryManagement.Application.Features;
using InventoryManagment.Endpoints.Dtos.ResponseDtos;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InventoryManagment.Endpoints.Endpoints
{
    public class TrackItemQuantity : EndpointWithoutRequest<BaseResponse>
    {
        public ITrackItemQuantity _trackItemQuantityFeature;
        public TrackItemQuantity(ITrackItemQuantity trackItemQuantityFeature)
        {
            _trackItemQuantityFeature = trackItemQuantityFeature;
        }
        public override void Configure()
        {
            Get("/api/track-quantity/{itemId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            string itemId = Route<string>("itemId");
            var quantity = await _trackItemQuantityFeature.GetItemQuantity(new Guid(itemId));
            await SendAsync(new()
            {
                Status = true,
                Message = "Ok",
                Result = quantity
            });
        }
    }
}
