using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WordWiz.Application.Common.Behaviors;

namespace WordWiz.Application.Common;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // MediatR
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        // AutoMapper
        services.AddAutoMapper(assembly);

        // FluentValidation
        services.AddValidatorsFromAssembly(assembly);

        // Validation Pipeline Behavior
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
} 