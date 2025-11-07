using MonHttpCs.Interfaces;
using MonHttpCs.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Register services for dependency injection
        builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        // Add Swagger for API documentation
        builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // app.UseSwagger();
            // app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}