using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connector_technical_eid.domain
{
    public class BeIDInfo
    {
        public Identity identity;
        public Address address;
        public byte[] photo;

        public override string ToString()
        {
            return "BeIDInfo: {" +
                "Identity: {"+identity.ToString()+"}" +
                 ", Address: {" + address.ToString() + "}" +
                "}";
        }

    }
}
