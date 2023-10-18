
using FakeItEasy;
using FastEndpoints;
using FluentAssertions;
using InventoryManagement.Application.Contracts.Features;

namespace InventoryManagement.UnitTest.APITest;
public class TrackItemQuantityUnitTest 
{
	 [Fact]
    public async Task TrackItemQuantity_Positive_Test()
    {
        // Arrange
        var itemId = Guid.NewGuid().ToString();
        var trackItemQuantity = A.Fake<ITrackItemQuantity>();
        var endpoint = Factory.Create<InventoryManagment.Endpoints.Endpoints.TrackItemQuantity>(
            ctx => ctx.Request.RouteValues.Add("itemId", new Guid().ToString()),
            trackItemQuantity
        );

        // Act
        await endpoint.HandleAsync(default);

        // Assert
        endpoint.Response.Should().NotBeNull();
        endpoint.Response.Status.Should().BeTrue();
    }
}