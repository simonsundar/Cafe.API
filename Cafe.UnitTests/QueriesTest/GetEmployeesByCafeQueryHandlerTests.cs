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


    public class GetEmployeesByCafeQueryHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _empRepositoryMock;
        private readonly GetEmployeesByCafeHandler _handler;

        public GetEmployeesByCafeQueryHandlerTests()
        {
            _empRepositoryMock = new Mock<IEmployeeRepository>();
            _handler = new GetEmployeesByCafeHandler(_empRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCafesByLocation()
        {
            // Arrange
            var query = new GetEmployeesByCafeQuery { CafeId = "test 1" };
            var emp = new List<Employee>
        {
            new Employee {  Name = "GIC Guy 1" , EmailAddress="manojkke@gmail.com",Gender="Male",Id = "test 1", PhoneNumber="8669-2323", StartDate = DateTime.Now}
        };
            _empRepositoryMock.Setup(repo => repo.GetByCafeAsync(query.CafeId))
                .ReturnsAsync(emp);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("GIC Guy 1", result.First().Name);
            Assert.Equal("test 1", result.First().Id);
        }
 
    }

}
