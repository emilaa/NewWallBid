using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WallBid.Infrastructure.Exceptions;

namespace WallBid.Business
{
    internal class ValidatorInterceptor : IValidatorInterceptor
    {
        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }

        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                var errors = result.Errors.GroupBy(m => m.PropertyName)
                    .ToDictionary(
                        k => k.Key,
                        v => v.Select(m => m.ErrorMessage)
                    );

                throw new BadRequestException("Model göndərilən tələblərə cavab vermir!", errors);
            }

            return result;
        }
    }

    public static class ValidatorInterceptorExtension
    {
        public static IServiceCollection AddFluentValidations(this IServiceCollection services)
        {
            services.AddScoped<IValidatorInterceptor, ValidatorInterceptor>();

            services.AddValidatorsFromAssemblyContaining<IValidatorReference>(includeInternalTypes: true);

            services.AddFluentValidationAutoValidation(cfg => cfg.DisableDataAnnotationsValidation = true);

            return services;
        }
    }
}
