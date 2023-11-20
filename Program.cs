using System.Text;
using System.Web.Http.Controllers;
using Ecc;
using Ecc.Context;
using Ecc.Integration;
using Ecc.Integration.Refit;
using Ecc.Repositories;
using Ecc.Repositories.Interfaces;
using Ecc.Services;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin());
}
);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IRepository<AuthorModel>, AuthorRepository>();
builder.Services.AddScoped<PasswordHashService>();
builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c => {
    c.BaseAddress = new Uri("https://viacep.com.br");
});
builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
