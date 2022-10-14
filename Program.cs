var builder = WebApplication.CreateBuilder(args);

var port = builder.Configuration["PORT"];

builder.WebHost.UseUrls($"http://*:{port};http://localhost:3000");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGet("/",()=>"Hello world 🥂");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();