namespace Plantskola_grupp4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // ⭐ Aktivera wwwroot
            app.UseStaticFiles();

            // ⭐ Gör så att "/" laddar index.html
            app.MapGet("/", () =>
            {
                return Results.Redirect("/index.html");
            });

            // ⭐ POST-Endpoint /submit
            app.MapPost("/submit", async context =>
            {
                var form = await context.Request.ReadFormAsync();
                var name = form["name"];
                var message = form["message"];

                // 🔹 SERVER-SIDE VALIDATION
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(message))
                {
                    await context.Response.WriteAsync($@"
                        <html>
                        <head>
                            <meta charset='UTF-8'>
                            <link rel='stylesheet' href='/styles.css'>
                        </head>
                        <body>
                            <h1>Fel!</h1>
                            <p>Du måste fylla i både namn och meddelande.</p>
                            <a href='/contact.html'>Tillbaka</a>
                        </body>
                        </html>
                    ");
                    return;
                }

                // 🔹 SERVER-GENERATED DYNAMIC HTML RESPONSE
                await context.Response.WriteAsync($@"
                    <html>
                    <head>
                        <meta charset='UTF-8'>
                    <link rel='stylesheet' href='styles.css'>
                    </head>
                    <body>
                        <h1>Tack {name}!</h1>
                        <p>Vi har mottagit ditt meddelande:</p>
                        <blockquote>{message}</blockquote>
                        <a href='/index.html'>Tillbaka till startsidan</a>
                    </body>
                    </html>
                ");
            });

            // ⭐ Kör applikationen
            app.Run();
        }
    }
}