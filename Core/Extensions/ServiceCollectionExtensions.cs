using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviseCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviseCollection);
            }
            return ServiceTool.Create(serviseCollection);
        }
    }
}
