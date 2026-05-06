using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Constants
{
    public static class DomainStatusCodes
    {
        public const int NotFound = 404;
        public const int BadRequest = 400;
        public const int UnprocessableEntity = 422;
    }
}
