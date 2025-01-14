using System.Runtime.InteropServices;
using API;
using API.Extensions;
using APPLICATION;
using INFRASTRUCTURE;
using INFRASTRUCTURE.ErrorHandler;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add Configuration
builder.Services.AddSingleton(builder.Configuration);

// Add services to the container.
// Infra dependency injection
InfraInjector.Inject(builder.Services, builder.Configuration);

// App dependency injection
AppInjector.Inject(builder.Services, builder.Configuration);

// Api dependency injection
ApiInjector.Inject(builder.Services, builder.Configuration);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressMapClientErrors = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.Parse(builder.Configuration["File:Limit"]); // (1024 * 1024 * 2048) 800 MB
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = long.Parse(builder.Configuration["File:Limit"]); // (1024 * 1024 * 2048) 800 MB
});

var app = builder.Build();


app.UseDeveloperExceptionPage();
/*
app.UseStatusCodePages();
app.UseExceptionHandler(exceptionhandler =>
{
    exceptionhandler.Run(async context =>
    {
        // using static System.Net.Mime.MediaTypeNames;
        context.Response.ContentType = Text.Plain;

        var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature == null)
        {
            return;
        }

        if (exceptionHandlerPathFeature.Error is Error400)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        } else if (exceptionHandlerPathFeature.Error is Error401)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
        else if (exceptionHandlerPathFeature.Error is Error404){
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        } 
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }

        await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.Message);
    });
});
*/

app.UseCors(x => x
    .WithOrigins("https://*:3001", "https://*:3001")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithExposedHeaders("*")
    .SetIsOriginAllowed(_ => true) // allow any origin
    .AllowCredentials()); // allow credential

// Hosting
var path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
    ? Path.Combine(builder.Configuration["File:LocationWIN32"], builder.Configuration["File:DestinationWIN32"])
    : Path.Combine(builder.Configuration["File:LocationLINUX"], builder.Configuration["File:DestinationLINUX"]);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(path),
    RequestPath = builder.Configuration["File:Request"]
});

app.UseSwaggerAuthorized();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    var title = app.Configuration["App"];

    c.DocumentTitle = title;

    if (app.Environment.IsProduction() || app.Environment.IsDevelopment())
    {
        c.SwaggerEndpoint($"/swagger/{title}/swagger.json", title);
    }
    else
    {
        c.SwaggerEndpoint($"/dev/swagger/{title}/swagger.json", title);
    }

    c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();