
using Project.Entities;

namespace Project;

public class Program
{
    public static void Main(string[] args)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            Category cat = new()
            {
                Id = default,
                Name = "Test"
            };
            Product first = new Product()
            {
                Id = default,
                Name = "test",
                Count = 1,
                Price = 1,
                Category = cat
            };

            // добавляем их в бд
            db.Products.Add(first);
            //db.Categories.Add(cat);
            db.SaveChanges();
        }
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ApplicationContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
