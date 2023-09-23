using NLog;
using NLog.Web;
using SystemEmail.IOC;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

logger.Debug("Start Log");

try
{
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.InjectDependences(builder.Configuration);
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    //activacion de Cors

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("NewRules", app =>
        {
            app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
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

    //activar la autorizacion.

    app.UseCors("NewRules");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{

    logger.Error(ex,"Program has stopped because there was an excepction");

}finally
{
    NLog.LogManager.Shutdown();
}
