using Microsoft.AspNetCore.Builder;
using SymphonicAvenue.WebAPI.Extensions;

namespace SymphonicAvenue.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services
                    .RegisterUIServices(builder);
            }

            var app = builder.Build();
            {
                app.AddMiddlewares();
            }

            app.Run();
        }
    }
}