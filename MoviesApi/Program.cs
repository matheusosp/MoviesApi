using MoviesApi.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(options => {options.Listen(System.Net.IPAddress.Any, 8080);});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDataAccessLayer, MongoDBDataAccessLayer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
