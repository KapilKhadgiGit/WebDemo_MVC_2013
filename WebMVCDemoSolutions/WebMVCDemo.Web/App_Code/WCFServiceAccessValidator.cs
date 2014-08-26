using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WebMVCDemo.Web.App_Code
{
    public class WCFServiceAccessValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "fayaz" && password == "fayaz1"))
            {
                throw new FaultException("Incorrect Username or Password");
            }
        }
    }
}