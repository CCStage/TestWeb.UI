using NewTestBlazorApp.Components;
using MudBlazor.Services;
using NewTestBlazorApp.Services;
using NewTestBlazorApp.BogusGeneration;
using NewTestBlazorApp.discarded;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddCircuitOptions(options => { options.DetailedErrors = true; }); ;
builder.Services.AddMudServices();


// Register services
builder.Services.AddSingleton<FolderService>();
builder.Services.AddSingleton<BogusFolderGeneration>();
builder.Services.AddSingleton<GeneralBogusDataGeneration>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
