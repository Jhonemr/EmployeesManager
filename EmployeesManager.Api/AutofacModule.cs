using Autofac;
using EmployeesManager.Business.Contracts;
using EmployeesManager.Business.Factories;
using EmployeesManager.Business.Services;
using EmployeesManager.DataAccess.Contracts;
using EmployeesManager.DataAccess.Repositories;
using EmployeesManager.Domain.Configuration;
using Microsoft.Extensions.Configuration;

namespace EmployeesManager.Api
{
    /// <summary>
    /// Register the Instances using a module, for more information
    /// http://docs.autofac.org/en/latest/configuration/modules.html
    /// </summary>
    public class AutofacModule : Module
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Register the Instances, for more information how to register instances and
        /// the instances scopes refer to http://autofac.readthedocs.io/en/latest/lifetime/instance-scope.html
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var appSettings = Configuration.Get<AppSettings>();

            // dependency injection
            builder.RegisterInstance<IConfiguration>(Configuration).SingleInstance();
            builder.RegisterInstance(appSettings).SingleInstance();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeesRepository>().As<IEmployeesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeFactory>().As<IEmployeeFactory>().InstancePerLifetimeScope();
        }
    }
}
