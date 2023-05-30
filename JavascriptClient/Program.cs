using JavascriptClient;

var builder = WebApplication.CreateBuilder(args);

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.Run();
