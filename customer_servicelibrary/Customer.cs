using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace customer_servicelibrary
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int cId { get; set; }

        [DataMember]
        public string cName { get; set; }

        [DataMember]

        public string cPhone { get; set; } 
    }
}
