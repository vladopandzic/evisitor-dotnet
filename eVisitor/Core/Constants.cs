using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Core
{
    public class Constants
    {
        public static string BaseUrl { get { return "https://www.evisitor.hr/eVisitorRhetos_API/Rest/Htz/"; } set { } }

        public static string LoginResource { get { return "Login"; } set { } }

        public static string CountriesResource { get { return "CountryLookup/"; } set { } }

        public static string LoginUrl = "https://www.evisitor.hr/eVisitorRhetos_API/Resources/AspNetFormsAuth/Authentication/";
    }
}
