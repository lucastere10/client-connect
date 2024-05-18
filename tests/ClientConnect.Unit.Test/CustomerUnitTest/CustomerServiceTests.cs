using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.Infrastructure.Data;
using ClientConnect.Infrastructure.Services;
using ClientConnect.UseCases.Dto.Customer;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ClientConnect.Unit.Test.CustomerUnitTest;

public class CustomerServiceTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<DbSet<Customer>> _dbSetMock;
    private readonly Mock<ClientConnectContext> _contextMock;
    private readonly Infrastructure.Services.CustomerService _customerService;

    public CustomerServiceTests()
    {
        _mapperMock = new Mock<IMapper>();
        _dbSetMock = new Mock<DbSet<Customer>>();
        _contextMock = new Mock<ClientConnectContext>();

        _contextMock.Setup(context => context.Customers).Returns(_dbSetMock.Object);

        _customerService = new CustomerService(_mapperMock.Object, _contextMock.Object);
    }

    [Fact]
    public void AddCustomer_ShouldAddCustomer()
    {
        // Arrange
        var customerDto = new CreateCustomerDto { Name = "Test", Email = "test@example.com" };
        Customer customer = new Customer { CustomerId = 1, Name = "Test", Email = "test@example.com" };

        _mapperMock.Setup(mapper => mapper.Map<Customer>(customerDto)).Returns(customer);

        // Act
        var result = _customerService.AddCustomer(customerDto);

        // Assert
        _dbSetMock.Verify(dbSet => dbSet.Add(customer), Times.Once);
        _contextMock.Verify(context => context.SaveChanges(), Times.Once);
        Assert.Equal(customer, result);
    }
}
