using DNH.Storage.EF.Services;
using DNH.Storage.EF.StartUp;
using Plugin.Abstraction.Plugins.Settings;
using Plugin.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            options.JsonSerializerOptions.WriteIndented = true;
        });
builder.Services.AddEndpointsApiExplorer();

var pluginSettings = new PluginSettings();
builder.Configuration.Bind("PluginLoader", pluginSettings);
//var kaffka = new KafkaSettings();
//builder.Configuration.Bind("Kafka", kaffka);
//builder.Services.AddSingleton(kaffka);
builder.Services.RegisterDB(builder.Configuration, PluginSettings.Assemblies);
builder.Services.AddMyServices(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();




AppDependencyResolver.Init(builder.Services.BuildServiceProvider());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
