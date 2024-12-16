using FipeBrasil.Application.Brand.Delete;
using FipeBrasil.Domain.Contracts;
using FluentAssertions;
using Moq;

namespace FipeBrasil.Application.Test.Brand
{
    public class DeleteBrandHandlerTests
    {
        private readonly Mock<IRepository<Domain.Entities.Brand>> _mockRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly DeleteBrandHandler _handler;

        public DeleteBrandHandlerTests()
        {
            _mockRepository = new Mock<IRepository<Domain.Entities.Brand>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new DeleteBrandHandler(_mockRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldDeleteBrand()
        {
            // Arrange
            var brand = new Domain.Entities.Brand("12345", "BrandName") { Id = Guid.NewGuid() };
            var command = new DeleteBrandCommand { Id = brand.Id };

            _mockRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync(brand);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Id.Should().Be(brand.Id);
            response.Name.Should().Be(brand.Name);

            _mockRepository.Verify(r => r.DeleteAsync(command.Id), Times.Once);
            _mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var command = new DeleteBrandCommand { Id = Guid.NewGuid() };

            _mockRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync((Domain.Entities.Brand)null);

            // Act
            var act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage("Brand not found.");

            _mockRepository.Verify(r => r.DeleteAsync(It.IsAny<Guid>()), Times.Never);
            _mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Never);
        }
    }


}
