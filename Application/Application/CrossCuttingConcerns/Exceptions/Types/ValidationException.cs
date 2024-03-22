using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CrossCuttingConcerns.Exceptions.Types
{
    public class ValidationException : Exception
    {
        public Dictionary<string, List<string>> Errors { get; set; }
        public ValidationException(Dictionary<string, List<string>> errors) : base()
        {
            Errors = errors;
        }

        public ValidationException(Dictionary<string, List<string>> errors, string message) : base(message)
        {
            Errors = errors;
        }
    }
}
