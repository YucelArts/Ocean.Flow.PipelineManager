
using Ocean.Activity.HttpClientService.Middleware;
using Ocean.Activity.ResponseService.Middleware;
using Ocean.Activity.SmtpClientService.Middleware;
using Ocean.Interface;
using Ocean.Service.PipelineManager;

namespace Ocean.Flow.PiplineManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.





            builder.Services.AddHttpClient<HttpClientJob>();

            builder.Services.AddScoped<HttpClientJob>();
            builder.Services.AddScoped<SmtpClientJob>();
            builder.Services.AddScoped<ResponseJob>();

            
            
            builder.Services.AddScoped<PipelineManagerService>();


            builder.Services.AddScoped<IPipelineFactory, PipelineFactory>();




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
