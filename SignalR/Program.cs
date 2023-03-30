using SignalR.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("SignalR",
        build =>
        {
            build.SetIsOriginAllowed(origen => true)
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("SignalR");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ClaseSignalR>("/SignalR");
});



app.MapGet("/", () => "Hello World!");


app.Run();
