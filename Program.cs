using Assessment_Task.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtAuthentication(configuration);
builder.Services.AddRepositories(configuration);
builder.Services.AddServices();
builder.Services.AddMapster();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<TokenBlacklistMiddleware>();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();

