using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace order_servicelibrary
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int oId { get; set; }

        [DataMember]
        public string foodName { get; set; }

        [DataMember]
        public int cId {  get; set; }

        [DataMember]
        public int total {  get; set; }

    }
}
