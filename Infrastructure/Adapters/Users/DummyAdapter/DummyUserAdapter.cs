using Application.Abstracts.Infrastructure.Adapters.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Users.DummyAdapter
{
    public class DummyUserAdapter : IUserAdapter
    {
        private readonly IConfiguration _configuration;

        public DummyUserAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetEmailById(int id)
        {
            return _configuration["DummyUserEmail"];
        }
    }
}
