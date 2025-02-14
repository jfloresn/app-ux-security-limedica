using app_ux_security_limedica.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseService>();

// Agregar soporte para compresión de respuesta
builder.Services.AddResponseCompression();

// Agregar soporte para CORS (define la política si no existe)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseResponseCompression();
app.UseCors("PermitirTodo");
app.UseRouting();

app.MapControllers();

app.Run();
