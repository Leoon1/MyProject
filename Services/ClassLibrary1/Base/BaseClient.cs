using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MyProject.Clients.Base
{
    public class BaseClient
    {
        protected string Address { get; }
        protected HttpClient Http { get; }

        protected BaseClient(IConfiguration configuration, string ServiceAddress)
        {
            Address = ServiceAddress;
            Http = new HttpClient
            {
                BaseAddress = new Uri(configuration["WebApiURL"]),
                DefaultRequestHeaders =
                {
                    Accept = {new MediaTypeWithQualityHeaderValue("application/json")}
                }
            };
        }
    }
}
