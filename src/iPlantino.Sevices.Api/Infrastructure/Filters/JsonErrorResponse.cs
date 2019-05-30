using System.Collections.Generic;

namespace iPlantino.Services.Api.Infrastructure.Filters
{
    public class JsonErrorResponse
    {
        public JsonErrorResponse()
        {
            Messages = new Dictionary<string, IEnumerable<string>>();
        }

        public IDictionary<string, IEnumerable<string>> Messages { get; set; }

        public object DeveloperMeesage { get; set; }
    }
}