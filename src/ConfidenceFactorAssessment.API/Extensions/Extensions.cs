using Microsoft.AspNetCore.Mvc;

using ConfidenceFactorAssessment.API.Controllers;

using ConfidenceFactorAssessment.API.Repository;
using ConfidenceFactorAssessment.API.Repository.Abstractions;

namespace ConfidenceFactorAssessment.API.Extensions;

public static class Extensions
{

    public static IHostApplicationBuilder ConfigureServices(this IHostApplicationBuilder builder)
    {

        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        builder.Services.AddCors(options => {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        builder.Services.Configure<IISOptions>(options =>
        {
        });

        return builder;
    }

    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddExceptionHandler<ExceptionHandlerService>();

        builder.AddNpgsqlDbContext<ConfidenceFactorAssessmentContext>("assessmentdb", configureDbContextOptions: dbContextOptionsBuilder =>
        {
   
        });

        builder.Services.AddScoped<AssessmentServices>();
        builder.Services.AddScoped<ValidationAttributeFilter>();

        builder.Services.AddScoped<IAssessmentRepository, AssessmentRepository>();
        builder.Services.AddScoped<ICriteriaRepository, CriteriaRepository>();
        builder.Services.AddScoped<IConfidenceFactorRepository, ConfidenceFactorRepository>();

        builder.Services.AddScoped<IAssessmentService, AssessmentService>();
        builder.Services.AddScoped<ICriteriaService, CriteriaService>();
        builder.Services.AddScoped<IConfidenceFactorService, ConfidenceFactorService>();

        builder.Services.AddScoped<AssessmentServiceManager>();
        builder.Services.AddScoped<AssessmentRepositoryManager>();

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddMigrations<ConfidenceFactorAssessmentContext, ConfidenceFactorAssessmentContextSeed>();
        }

        return builder;
    }
}

