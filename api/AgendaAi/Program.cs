using AgendaAi.DB;
using Microsoft.EntityFrameworkCore;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AgendaDB>(opt => opt.UseInMemoryDatabase("AgendaAi"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
  options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                      policy.WithOrigins("*");
                    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pessoa API v1");
      c.RoutePrefix = string.Empty; // Para acessar na raiz
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);


app.Run();
