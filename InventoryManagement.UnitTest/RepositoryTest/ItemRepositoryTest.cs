using FakeItEasy;
using FluentAssertions;
using InventoryManagement.Application.Contracts.Persistance;
using InventoryManagement.Domain;
using InventoryManagement.Persistance;
using InventoryManagement.Persistance.Repositories;

namespace InventoryManagement.UnitTest;

public class ItemRepositoryTest
{
    [Fact]
    public async Task DecreaseItemQuantity_DecreaseQuantity()
    {
        // Arrange
        var itemId = Guid.NewGuid();
        var initialQuantity = 10;
        var decreaseQuantity = 5;

        var item = new Item { Id = itemId, Quantity = initialQuantity};
        var repository = A.Fake<IItemRepository>();

        // Act
        await repository.DecreaseItemQuantity(itemId, decreaseQuantity);

        // Assert
        item.Quantity.Should().Be(5);
      
    }
}
