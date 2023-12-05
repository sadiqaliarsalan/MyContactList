using MyContactList.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IContactRepository, ContactRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyBlazorAppPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:7249") // frontend application url
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy
app.UseCors("MyBlazorAppPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
