using CloudCustomer.API.Models;

namespace CloudCustomer.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(yhApiContext context)
        {
            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Name="Yaron", Email="yaron@nav.net", Address = new Address{ Street="1024 Cedar st.", City="Carson City", ZipCode="89701-7004"} }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}