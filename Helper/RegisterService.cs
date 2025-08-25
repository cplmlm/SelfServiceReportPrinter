using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace SelfServiceReportPrinter;

public static class RegisterService
{
    public static void Register(this ServiceCollection services)
    {
        var assembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services.dll"));     
        foreach (var type in assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract))
        {
            var interfaceName= type.GetInterfaces().FirstOrDefault();
            services.AddTransient(interfaceName, type);              
        }
    }
}
