using Application.CrossCuttingConcerns.Exceptions.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters
{
    public class BaseAdapter
    {

        protected TResponse HandleHttpResponse<TResponse>(
            HttpResponseMessage httpResponseMessage,
            string dependedAdapterName="Adapter"
        ) where TResponse: class,new()
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new BusinessException($"Some problem occured in {dependedAdapterName}");

            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            TResponse response = JsonConvert.DeserializeObject<TResponse>(content);

            return response;
        }
    }
}
