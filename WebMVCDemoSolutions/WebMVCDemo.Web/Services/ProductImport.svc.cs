using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebMVCDemo.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductImport" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductImport.svc or ProductImport.svc.cs at the Solution Explorer and start debugging.
    public class ProductImport : IProductImport
    {
        public void DoWork()
        {
        }

        public string ProductData()
        {
            return "Success!!!";
        }
    }
}
