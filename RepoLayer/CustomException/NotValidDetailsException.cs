using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.CustomException
{
    public class NotValidDetailsException: Exception
    {
        public NotValidDetailsException(string message):base(message) { }
    }
}
