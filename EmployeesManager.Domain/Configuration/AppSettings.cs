using System;

namespace EmployeesManager.Domain.Configuration
{
    /// <summary>
    /// Represents the application settings that are set in the appsettings.json
    /// </summary>
    public class AppSettings
    {
        public Uri ExployeesExternalApi { get; set; }
        public string ExployeesResource { get; set; }
    }
}
