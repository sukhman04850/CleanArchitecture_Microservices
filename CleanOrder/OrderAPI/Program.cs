
using OrderApplication.Interfaces;
using OrderApplication.Mapper;
using OrderApplication.Services;
using OrderInfrastructure.KafkaConfiguration;
using OrderInfrastructure.KafkaConsumers;
using OrderInfrastructure.Repository;
using Serilog;

namespace OrderAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddSingleton<KafkaConsumer>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.Configure<KafkaSettings>(builder.Configuration.GetSection("KafkaConfig"));
            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
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
            var cancellationToken = new CancellationToken();
            var kafkaConsumers = app.Services.GetRequiredService<KafkaConsumer>();
            kafkaConsumers.ExecuteAsync(cancellationToken);
            app.UseSerilogRequestLogging();


            app.Run();
        }
    }
}
