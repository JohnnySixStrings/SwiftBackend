using SwiftBackend.Data;
using SwiftBackend.Middleware;
using SwiftBackend.Static;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await app.Services.CreateAndUpdateDatabase();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
//app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
