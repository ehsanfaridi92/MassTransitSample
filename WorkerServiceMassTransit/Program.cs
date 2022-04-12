using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossCuttingLayer;
using GreenPipes;
using MassTransit;
using RabbitMQ.Client;
using WorkerServiceMassTransit.Consumers;

namespace WorkerServiceMassTransit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {

                    services.AddScoped<ITest11, Test11>();
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<TodoConsumer11>();
                        x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                        {
                            cfg.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), h =>
                            {
                                h.Username(RabbitMqConsts.UserName);
                                h.Password(RabbitMqConsts.Password);
                            });
                            cfg.ReceiveEndpoint("test____todoQueue11", ep =>
                            {
                                ep.ConfigureConsumer<TodoConsumer11>(provider);
                                ep.ConfigureConsumeTopology = false;
                                ep.ExchangeType = ExchangeType.Direct;
                                ep.EnablePriority(4);
                                ep.PrefetchCount = 1;
                                ep.UseMessageRetry(messageConfig => messageConfig.Interval(2, 100));
                            });
                        }));
                    });
                    services.AddMassTransitHostedService();


                    services.AddHostedService<Worker>();
                });
    }
}
