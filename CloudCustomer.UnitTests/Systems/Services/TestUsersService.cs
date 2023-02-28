using CloudCustomer.API.Models;
using CloudCustomer.API.Services;
using CloudCustomer.UnitTests.Fixtures;
using CloudCustomer.UnitTests.Helpers;
using Moq;
using Moq.Protected;

namespace CloudCustomer.UnitTests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UsersService(httpClient, null);

            // Act
            await sut.GetAllUsers();

            //Assets
            //Verify HTTP request is made
            handlerMock
                .Protected()
                .Verify(
                    "SendAsync", 
                    Times.Exactly(1), 
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>()
                 );

        }
    }
}
