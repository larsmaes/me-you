var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IConfiguration config = app.Configuration;

HttpClient client = new HttpClient();

app.MapGet("/", () => "Hello World!");
app.MapGet("/me", () => $"{{ \"response\": \"{config["APP_ME"]}\" }}");
app.MapGet("/you", async () => {
  HttpResponseMessage response = await client.GetAsync(config["APP_YOU"]);
  return await response.Content.ReadAsStringAsync();
});

app.Run();
