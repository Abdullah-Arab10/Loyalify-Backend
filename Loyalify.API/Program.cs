using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Hangfire;
using Loyalify.API;
using Loyalify.Application;
using Loyalify.Infrastructure;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential
    .FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
    "")),
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
}
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin 
    .AllowCredentials());

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Uploads")),
    RequestPath = new PathString("/Uploads")
});
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();
app.Run();
