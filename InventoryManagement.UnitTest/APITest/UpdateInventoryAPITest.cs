
using FakeItEasy;
using FastEndpoints;
using FluentAssertions;
using InventoryManagement.Application.Contracts.Features;
using InventoryManagement.Infrastructure.Queue.Contracts;
using InventoryManagment.Endpoints.Dtos.RequestDtos;
using InventoryManagment.Endpoints.Endpoints;
namespace InventoryManagement.UnitTest;

public class UpdateInventoryAPITest
{
    [Fact]
    public async Task HandleAsync_WhenInOutIsTrue_CallsAddItemQuantity()
    {

        // Arrange
        var updateQuantity = A.Fake<IUpdateQuantity>();
        var messageQueueService = A.Fake<IMessageQueueService>();
        var endpoint = Factory.Create<UpdateItemQuantity>(
            updateQuantity,
            messageQueueService
        );
        var dto = new UpdateItemQuantityRequest()
        {
            ItemId = new Guid(),
            ChangedQuantity = 5,
            InOut = true
        };

        // Act
        await endpoint.HandleAsync(dto, default);

        // Assert
        endpoint.Response.Should().NotBeNull();
        endpoint.Response.Message.Should().Be("Item Quantity Updated Succesfully");
        endpoint.Response.Status.Should().BeTrue();
    }

   
}
