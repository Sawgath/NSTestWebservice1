using NSTestWebservice1.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace NSTestWebservice1.Controllers
{
    public class UserDataController : ApiController
    {
        //[HttpPost]
        //public HttpResponseMessage Post(FetchData afUser)
        //{
        //    string text = afUser.Username;

        //    //1st stage of solution----------------------------------------------------------------------
        //    string pat = @"(\bor\b|\bselect\b|\bfrom\b|\binto\b|\bwhere\b|\binsert\b|\bupdate\b|\bdelete\b|\bdrop\b|\bcreate\b|\balter\b|\band\b|\bunion\b|\bjoin\b|\-{2,}|\"|\*|\\|\/|\=|\')";

        //    // Instantiate the regular expression object.
        //    Regex r = new Regex(pat, RegexOptions.IgnoreCase);

        //    // Match the regular expression pattern against a text string.
        //    Match m = r.Match(text);
        //    if (m.Success)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Forbidden, "You tried to do sql Injection");
        //    }
        //    //--------------------------------------------------------------------------------------------
        //    OtherFunctions aother = new OtherFunctions();
        //    return Request.CreateResponse(aother.GetAll(afUser.Username));
        //}




        [HttpPost]
        public HttpResponseMessage unsafePost(FetchData afUser)
        {

            HttpResponseMessage response = null;
            //{"Username":"asdgajlu' or '1'='1"}
            OtherFunctions aother = new OtherFunctions();
            int userlength = afUser.Username.Length;
            if (userlength <= 12)
            {
                
                var alist = aother.unsafeGetAll(afUser.Username);
                //return aother.unsafeGetAll(afUser.Username);
                response = Request.CreateResponse(HttpStatusCode.OK, alist);
                return response;
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Username more then 12 char. ");
                return response;

            }

            

        }




    }
}
