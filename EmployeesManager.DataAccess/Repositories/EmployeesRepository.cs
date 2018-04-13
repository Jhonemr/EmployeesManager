using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using EmployeesManager.DataAccess.Contracts;
using EmployeesManager.Domain.Models;
using EmployeesManager.Domain.Configuration;
using Newtonsoft.Json;

namespace EmployeesManager.DataAccess.Repositories
{
    /// <summary>
    /// Handles the data access for employees.
    /// </summary>
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly AppSettings _appSettings;
        private IList<EmployeeModel> _employees;

        public EmployeesRepository(AppSettings appSettings)
        {
            _appSettings = appSettings;
            LoadEmployees();
        }

        /// <summary>
        /// Gets all stored employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        public IList<EmployeeModel> GetAll()
        {
            return _employees;
        }

        /// <summary>
        /// Gets an stored employee by id.
        /// </summary>
        /// <returns>An employee.</returns>
        public EmployeeModel GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Returns a client pointing to the self hosted scheduler.
        /// </summary>
        /// <returns>The http client.</returns>
        private HttpClient GetClient()
        {
            var client = new HttpClient { BaseAddress = _appSettings.ExployeesExternalApi };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        /// <summary>
        /// Loads the employess from the Web API.
        /// </summary>
        private void LoadEmployees()
        {
            try
            {
                var client = GetClient();
                var response = client.GetAsync(_appSettings.ExployeesResource).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _employees = JsonConvert.DeserializeObject<IList<EmployeeModel>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new Exception($"Error calling API: {_appSettings.ExployeesExternalApi}. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calling API: {_appSettings.ExployeesExternalApi}. Ex: {ex.Message}");
            }
        }
    }
}
