using HelpDebugGov.Api.Configurations;

using HelpDebugGov.Api.Common;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers(options => {
    options.AllowEmptyInputInBodyModelBinding = true;
    options.Filters.Add<ValidationErrorResultFilter>();
}).AddValidationSetup();
builder.Services.AddAuthSetup(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
app.UseResponseCompression();
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();

app.Run();
