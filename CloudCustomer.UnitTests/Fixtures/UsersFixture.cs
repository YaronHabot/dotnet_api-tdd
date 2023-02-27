using CloudCustomer.API.Models;

namespace CloudCustomer.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User {
                    Id = 1,
                    Name= "Test user 1",
                    Address= new Address()
                    {
                        Street = "123 Market st",
                        City = "Madison",
                        ZipCode = "53704"
                    },
                    Email = "test.user.1@example.com"
                },
                new User {
                    Id = 2,
                    Name= "Test user 2",
                    Address= new Address()
                    {
                        Street = "123 Main st",
                        City = "Madison",
                        ZipCode = "53704"
                    },
                    Email = "test.user.2@example.com"
                },
                new User {
                    Id = 3,
                    Name= "Test user 3",
                    Address= new Address()
                    {
                        Street = "108 Maple st",
                        City = "Madison",
                        ZipCode = "53704"
                    },
                    Email = "test.user.3@example.com"
                }
            };
        
    }
}
