using NSTestWebservice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NSTestWebservice1.Controllers
{
    public class DataController : ApiController
    {
        public User Get()
        {

            User aUser = new User();
            aUser.Username = "Halu";
            aUser.Address = "Central SYD";
            aUser.Email = "admin@yga.com";
            aUser.Age = "25";


            FetchData afUser = new FetchData();
            afUser.Username = "Halu";
           

            return aUser;
        }


        [HttpPost]
        public string Post(User aUser)
        {

            OtherFunctions aother = new OtherFunctions();

            aother.Save(aUser);

            return "done";

        }





        


        [Route("api/Data/{id}")]
        [HttpGet]
        public string Get(int id)
        {

            if (id == 1)
            {



                return "worng id";

            }
            else
            {
                return "worng id";
            }

           
        }




       


    }
}
