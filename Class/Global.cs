using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManorGen.Class
{
    class Global
    {
        public static Manor Manor = new Manor()
        {
            Conf = new Conf(),
        };
    }
}
