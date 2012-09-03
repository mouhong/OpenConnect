using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Clients.Taobao
{
    [DataContract, Serializable]
    public class Location
    {
        [DataMember] string zip = null;
        [DataMember] string city = null;
        [DataMember] string state = null;
        [DataMember] string country = null;
        [DataMember] string district = null;

        public string Zip
        {
            get
            {
                return zip;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
        }

        public string State
        {
            get
            {
                return state;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
        }

        public string District
        {
            get
            {
                return district;
            }
        }

        public Location()
        {
        }
    }
}
