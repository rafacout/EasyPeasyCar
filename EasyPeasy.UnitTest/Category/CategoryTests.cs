using EasyPeasy.Domain.Repositories;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using Moq;

namespace EasyPeasy.UnitTest.Category;

public class CategoryTests
{
    [Fact]
    public async Task Category_Should_Avoid_Duplicated_Name()
    {
        // // Arrange
        // var categoryRepository = new Mock<ICategoryRepository>();
        // var unitOfWork = new Mock<IUnitOfWork>();
        //
        // unitOfWork.Setup(x => x.Categories).Returns(categoryRepository.Object);
        //
        // var categoryCommand = new CreateCategoryCommandHandler(unitOfWork.Object);
        // var category = new CreateCategoryCommand { Name = "Category 1" };
        //
        // categoryRepository.Setup(x => x.GetByNameAsync(category.Name)).ReturnsAsync(category);
        //
        // // Act
        // var result = await categoryCommand.Handle(category, CancellationToken.None);
        //
        // // Assert
        // Assert.False(result.Success);
        // Assert.Equal("Category already exists", result.Result.Message);
    }
}