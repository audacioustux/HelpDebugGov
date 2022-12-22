using HelpDebugGov.Api.Common;
using HelpDebugGov.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("default",
                      builder =>
                      {
                          builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});
builder.Services.AddControllers(options =>
{
    options.AllowEmptyInputInBodyModelBinding = true;
    options.Filters.Add<ValidationErrorResultFilter>();
}).AddValidationSetup();
builder.Services.AddAuthSetup(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSetup();
builder.Services.AddPersistenceSetup(builder.Configuration);
builder.Services.AddApplicationSetup();
builder.Services.AddCompressionSetup();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatRSetup();
builder.Services.AddFluentEmailSetup();
builder.Services.AddScoped<ExceptionHandlerMiddleware>();
builder.Logging.ClearProviders();
if (builder.Environment.EnvironmentName != "Testing")
    builder.Host.UseLoggingSetup(builder.Configuration);
builder.AddOpenTemeletrySetup();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    await app.Migrate();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseResponseCompression();
}
app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
app.UseSwaggerSetup();
app.UseCors("default");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();

await app.RunAsync();