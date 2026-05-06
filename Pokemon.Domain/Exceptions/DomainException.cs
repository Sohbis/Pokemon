using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Exceptions
{
    public abstract class DomainException:Exception
    {
        public int StatusCode { get; }
        protected DomainException(string message,int statuscode):base(message)
        {
            StatusCode = statuscode;
        }
    }
}
