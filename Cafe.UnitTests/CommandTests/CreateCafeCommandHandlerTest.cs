using GICCafe.Domain.Entities;
using GICCafe.Domain.Intefaces;
using GICCafe.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;


namespace GICCafe.UnitTests.Repositories
{
    public class CreateCafeCommandHandlerTest
    {
        private readonly Mock<ICafeRepository> _cafeRepositoryMock;
        private readonly CreateCafeCommandHandler _handler;

        public CreateCafeCommandHandlerTest()
        {
            _cafeRepositoryMock = new Mock<ICafeRepository>();
            _handler = new CreateCafeCommandHandler(_cafeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateCafe()
        {
            // Arrange
            var command = new CreateCafeCommand
            {
                Cafe = new Cafe
                {
                    Id = "cafe3",
                    Name = "Cafe Americano",
                    Description = "A vibrant place for coffee enthusiasts",
                    Location = "Midtown"
                }
            };

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _cafeRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Cafe>()), Times.Once);
        }
    }

}
