using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebMVCDemo.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductImport" in both code and config file together.
    [ServiceContract]
    public interface IProductImport
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string ProductData();
    }
}
