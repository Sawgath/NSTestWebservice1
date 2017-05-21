using NSTestWebservice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NSTestWebservice1.Controllers
{
    public class Data1Controller : ApiController
    {



        [HttpPost]
        public List<User> Post(FetchData afUser)
        {


            //{"Username":"asdgajlu' or '1'='1"}
            OtherFunctions aother = new OtherFunctions();



            return aother.GetAll(afUser.Username);

        }

    }
}
