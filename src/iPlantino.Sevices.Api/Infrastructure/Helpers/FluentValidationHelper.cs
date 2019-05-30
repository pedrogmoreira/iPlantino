using iPlantino.Services.Api.Models.Validations;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace iPlantino.Services.Api.Infrastructure.Helpers
{
    public static class FluentValidationHelper
    {
        public static IMvcBuilder ConfigureFluentValidation(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<LoginModelValidation>();
                options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
        }
    }
}