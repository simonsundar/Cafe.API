using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using GICCafe.Application.Queries;
using MongoDB.Driver;
using Xunit;
using GICCafe.Domain.Entities;
using GICCafe.Domain.Intefaces;


namespace GICCafe.UnitTests.QueriesTest
{
    // Tests/Handlers/GetCafesByLocationQueryHandlerTest.cs


    public class GetCafesByLocationQueryHandlerTest
    {
        private readonly Mock<ICafeRepository> _cafeRepositoryMock;
        private readonly Mock<IEmployeeRepository> _empRepositoryMock;
        private readonly GetCafesByLocationQueryHandler _handler;

        public GetCafesByLocationQueryHandlerTest()
        {
            _cafeRepositoryMock = new Mock<ICafeRepository>();
            _empRepositoryMock = new Mock<IEmployeeRepository>();
            _handler = new GetCafesByLocationQueryHandler(_cafeRepositoryMock.Object, _empRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCafesByLocation()
        {
            // Arrange
            var query = new GetCafesByLocationQuery { Location = "Downtown" };
            var cafes = new List<Cafe>
        {
            new Cafe { Name = "Cafe Mocha", Location = "Downtown", Employees = new List<Employee>() }
        };
            _cafeRepositoryMock.Setup(repo => repo.GetByLocationAsync(query.Location))
                .ReturnsAsync(cafes);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("Cafe Mocha", result.First().Name);
        }

        [Fact]
        public async Task Handle_ShouldNotReturnCafesByLocation()
        {
            // Arrange
            var query = new GetCafesByLocationQuery { Location = "Downtown" };
            var cafes = new List<Cafe>
        {
            new Cafe { Name = "Cafe Mocha 2", Location = "Downtown", Employees = new List<Employee>() }
        };
            _cafeRepositoryMock.Setup(repo => repo.GetByLocationAsync(query.Location))
                .ReturnsAsync(cafes);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.NotEqual("Cafe Mocha", result.First().Name);
        }
    }

}
