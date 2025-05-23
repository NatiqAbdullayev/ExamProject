using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.BL.Exceptions
{
    public class AccountException:Exception
    {
        public AccountException(string msg):base(msg)
        {
            
        }
    }
}
