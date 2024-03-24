using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstracts.Infrastructure.Adapters.Users
{
    /// <summary>
    /// This is dummy api which we try to imitate as another microservice.
    /// </summary>
    public interface IUserAdapter
    {
        string GetEmailById(int id);
    }
}
