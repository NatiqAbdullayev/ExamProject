using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.BL.Exceptions
{
    public class ProductException:Exception
    {
        public ProductException(string msg):base(msg)
        {
            
        }
    }
}
