using HelpDebugGov.Api.Common;
using HelpDebugGov.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
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
builder.Services.AddScoped<ExceptionHandlerMiddleware>();
builder.Logging.ClearProviders();
if (builder.Environment.EnvironmentName != "Testing")
    builder.Host.UseLoggingSetup(builder.Configuration);
builder.AddOpenTemeletrySetup();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseResponseCompression();
}
app.UseSwaggerSetup();
app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();

await app.Migrate();
await app.RunAsync();