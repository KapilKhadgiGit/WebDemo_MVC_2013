using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebMVCDemo.Web.Models
{
    [Serializable]
    public class DepartmentDetails
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Location { get; set; }
    }
}