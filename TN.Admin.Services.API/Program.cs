using TN.Admin.Services.API.Mapping;
using TN.Admin.Services.API.Middleware;
using TN.Admin.Services.API.Services.Implementation;
using TN.Admin.Services.API.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
{
	// Add services to the container.
	builder.Services.AddScoped<ICatalogService, CatalogService>();
	builder.Services.AddMappings();
	
	builder.Services.AddControllers();
	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseMiddleware<ErrorHandlingMiddleware>();
	//app.UseExceptionHandler("/error"); // Another way to handling errors 
	app.UseHttpsRedirection();
	app.UseAuthorization();
	app.MapControllers();
	app.Run();
}

