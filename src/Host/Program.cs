using Techsnovel.Host;
using Techsnovel.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebUIServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    // Initialise and seed database
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUI();

app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.Run();

// using Techsnovel.Host;
// using Techsnovel.Infrastructure.Persistence;
//
// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
// builder.Services.AddApplicationServices();
// builder.Services.AddInfrastructureServices(builder.Configuration);
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
//     app.UseMigrationsEndPoint();
//     
//     app.UseSwaggerUI();
//
//     // Initialise and seed database
//     using (var scope = app.Services.CreateScope())
//     {
//         var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
//         await initialiser.InitialiseAsync();
//         await initialiser.SeedAsync();
//     }
// }
// else
// {
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }
//
// app.UseHealthChecks("/health");
// app.UseHttpsRedirection();
// app.UseStaticFiles();
//
//
// app.UseRouting();
//
// app.UseAuthentication();
// app.UseIdentityServer();
// app.UseAuthorization();
// app.MapControllers();
//
// // app.MapControllerRoute(
// //     name: "default",
// //     pattern: "{controller}/{action=Index}/{id?}");
// //
// // app.MapRazorPages();
// //
// // app.MapFallbackToFile("index.html");
//
// app.Run();