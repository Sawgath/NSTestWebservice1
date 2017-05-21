using NSTestWebservice1.Models;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace NSTestWebservice1.Controllers
{
    public class Data1Controller : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(FetchData afUser)
        {
            string text = afUser.Username;
            string pat = @"(\bor\b|\bselect\b|\bfrom\b|\binto\b|\bwhere\b|\binsert\b|\bupdate\b|\bdelete\b|\bdrop\b|\bcreate\b|\balter\b|\band\b|\bunion\b|\binner\b|\bouter\b|\bjoin\b|\-{2,}|\*|\\|\/|\=|\'|\`)";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(text);
            if (m.Success)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "You tried to do sql Injection");
            }
            OtherFunctions aother = new OtherFunctions();
            return Request.CreateResponse(aother.GetAll(afUser.Username));
        }
    }
}
