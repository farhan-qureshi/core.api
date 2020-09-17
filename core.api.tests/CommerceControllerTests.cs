using core.api.commerce.Data.Interfaces;
using core.api.commerce.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;
using Moq;

namespace core.api.commerce.tests
{
    public class CommerceControllerTests
    {
        [Fact]
        public async void GetAllProducts_CallsRepositoryMethod_GetAllProductsAsync()
        {
            var logger = new Mock<ILogger<CommerceController>>();
            var repository = new Mock<ICommerceRepository>();
            var controller = new CommerceController(logger.Object, repository.Object);

            await controller.GetAllProducts();
            repository.Verify(r => r.GetAllProductsAsync(), Times.Once());
        }

        [Fact]
        public async void GetAllProducts_WhenRepositoryMethodReturnsNull_Returns_NotFound()
        {
            var logger = new Mock<ILogger<CommerceController>>();
            var repository = new Mock<ICommerceRepository>();
            repository.Setup(r => r.GetAllProductsAsync()).Throws(new System.Exception());

            var controller = new CommerceController(logger.Object, repository.Object);
            var result = await controller.GetAllProducts();
            var routeResult = Assert.IsAssignableFrom<ObjectResult>(result);

            Assert.Equal(routeResult.StatusCode, (int)HttpStatusCode.InternalServerError);
        }

        // More Tests to come
    }
}
