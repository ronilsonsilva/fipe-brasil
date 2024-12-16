using FipeBrasil.Infrastructure.Data;
using FipeBrasil.Jobs;
using FipeBrasil.WorkerService.Midleware;
using Hangfire;
using Hangfire.SqlServer;
using Refit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHangfire(config =>
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseDefaultTypeSerializer()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
          {
              CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
              SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
              QueuePollInterval = TimeSpan.FromSeconds(15),
              UseRecommendedIsolationLevel = true,
              DisableGlobalLocks = true
          }));

builder.Services.AddHangfireServer();

// Configuração dos Jobs
builder.Services.AddJobs();

builder.Services.AddRefitClient<IFipeApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://parallelum.com.br"));

builder.Services.AddScoped<UpsertDataJob>();

// Configuração da Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHostedService(provider =>
    new ExceptionHandlingBackgroundService(
        provider.GetRequiredService<IHostApplicationLifetime>(),
        provider.GetRequiredService<ILogger<ExceptionHandlingBackgroundService>>(),
        async token =>
        {
            using var scope = provider.CreateScope();
            var upsertJob = scope.ServiceProvider.GetRequiredService<UpsertDataJob>();
            await upsertJob.Execute();
        }
    )
);

var host = builder.Build();

// Execução temporária do UpsertDataJob na inicialização
//using (var scope = host.Services.CreateScope())
//{
//    var upsertDataJob = scope.ServiceProvider.GetRequiredService<UpsertDataJob>();
//    await upsertDataJob.Execute(); // Executa o job imediatamente
//}

// Configuração do Hangfire para o Job Recorrente
using var hangfireScope = host.Services.CreateScope();
var recurringJobManager = hangfireScope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
var recurringUpsertDataJob = hangfireScope.ServiceProvider.GetRequiredService<UpsertDataJob>();

// Comentado para evitar execução inicial dupla
recurringJobManager.AddOrUpdate<UpsertDataJob>(
    "UpsertDataJob",
    job => job.Execute(),
    Cron.Hourly
);

host.Run();
