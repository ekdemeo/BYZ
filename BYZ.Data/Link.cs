using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BYZ.Data
{
    /*
     * "uid" : 1,
		"user" : 1,
		"time" : 0,
		"pol" : 1,
		"byz" : 1,
		"the" : 0
     */
    public class Link
    {
        public Link(int pol, int byz)
        {
            Pol = pol;
            Byz = byz;
        }

        public int Uid { get; set; }

        public int Pol { get; set; }

        public int Byz { get; set; }

        public int The { get; set; }
    }
}
