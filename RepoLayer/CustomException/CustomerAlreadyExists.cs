using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.CustomException
{
    public class CustomerAlreadyExists:Exception
    {
        public CustomerAlreadyExists(string message):base(message) { }
    }
}
