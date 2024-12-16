using FipeBrasil.Application.Brand.Update;
using FipeBrasil.Domain.Contracts;
using FluentAssertions;
using Moq;

namespace FipeBrasil.Application.Test.Brand
{
    public class UpdateBrandHandlerTests
    {
        private readonly Mock<IRepository<Domain.Entities.Brand>> _mockRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly UpdateBrandHandler _handler;

        public UpdateBrandHandlerTests()
        {
            _mockRepository = new Mock<IRepository<Domain.Entities.Brand>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new UpdateBrandHandler(_mockRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldUpdateBrand()
        {
            // Arrange
            var brand = new Domain.Entities.Brand("12345", "OldName") { Id = Guid.NewGuid() };
            var command = new UpdateBrandCommand { Id = brand.Id, Code = "54321", Name = "NewName" };

            _mockRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync(brand);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Id.Should().Be(command.Id);
            response.Code.Should().Be(command.Code);
            response.Name.Should().Be(command.Name);

            _mockRepository.Verify(r => r.UpdateAsync(It.Is<Domain.Entities.Brand>(b => b.Code == command.Code && b.Name == command.Name)), Times.Once);
            _mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var command = new UpdateBrandCommand { Id = Guid.NewGuid(), Code = "54321", Name = "NewName" };

            _mockRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync((Domain.Entities.Brand)null);

            // Act
            var act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage("Brand not found.");

            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Domain.Entities.Brand>()), Times.Never);
            _mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Never);
        }
    }


}
