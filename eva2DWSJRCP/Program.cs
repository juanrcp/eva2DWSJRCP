using EntityBasicoDAL.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Añadimos servicio con la cadena de conexion de la BBDD y poder mostrar la informacion en vista.
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<BdEvaluacionContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("conexion"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
