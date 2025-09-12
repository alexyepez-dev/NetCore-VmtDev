using VMT.ERP.Application.Extension;
using VMT.ERP.Persistence.Extension;
using VMT.ERP.Utils.Exception;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(
    options => 
    options.Filters.Add(typeof(ExceptionManager)));

builder.Services
    .AddApplication()
    .AddPersistence(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();