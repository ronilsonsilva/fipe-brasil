using FipeBrasil.Application.Brand.Create;
using FipeBrasil.Domain.Contracts;
using FluentAssertions;
using Moq;

namespace FipeBrasil.Application.Test.Brand
{
    public class CreateBrandHandlerTests
    {
        private readonly Mock<IRepository<Domain.Entities.Brand>> _mockRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateBrandHandler _handler;

        public CreateBrandHandlerTests()
        {
            _mockRepository = new Mock<IRepository<Domain.Entities.Brand>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreateBrandHandler(_mockRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldCreateBrand()
        {
            // Arrange
            var command = new CreateBrandCommand { Code = "12345", Name = "BrandName" };

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Code.Should().Be(command.Code);
            response.Name.Should().Be(command.Name);

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Domain.Entities.Brand>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
        }
    }
}
