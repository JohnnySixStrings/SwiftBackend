using SwiftBackend.Data;

namespace SwiftBackend.Static
{
    public static class DatabaseCreationExtensions
    {
        public static async Task CreateAndUpdateDatabase(this IServiceProvider provider)
        {
           await using var scope = provider.CreateAsyncScope();
           var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
           await db.Database.EnsureDeletedAsync();
           await db.Database.EnsureCreatedAsync();
           
        }
    }
}
