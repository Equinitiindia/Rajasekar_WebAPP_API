using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TESTAPI2208.Models;
namespace TESTAPI2208.Controllers
{


    [RoutePrefix("api/TestApi")]
    public class TestApiController : ApiController
    {
       static readonly string pathname = @"C:\Users\Administrator\Desktop\TEST2208\UserData.txt";
        [HttpGet]
        [Route("GetSampleData")]
        //api/TestApi/GetSampleData/1
        public List<ClsUser> GetSampleData()
        {
            var filetext = System.IO.File.ReadAllText(pathname);
            List<ClsUser> lstUser = JsonConvert.DeserializeObject<List<ClsUser>>(filetext);
            return lstUser;
        }

        [HttpGet]
        [Route("DeleteById/1")]

        //api/TestApi/DeleteById/1
        public void DeleteById(string id= "3f2b12b8-2a06-45b4-b057-45949279b4e5")
        {

            var filetext = System.IO.File.ReadAllText(pathname);
            List<ClsUser> lstUser = JsonConvert.DeserializeObject<List<ClsUser>>(filetext);

            ClsUser objectuser = (from rowobject in lstUser where rowobject.Id == id  select rowobject).FirstOrDefault();

            lstUser.Remove(objectuser);
            System.IO.File.WriteAllText(@"C:\Users\Administrator\Desktop\TEST2208\UserDelete.txt", JsonConvert.SerializeObject(lstUser));
                      

        }
        [HttpPut]
        [Route("UpdateDataById/1")]

        // api/TestApi/UpdateDataById/1
        public IHttpActionResult UpdateDataById(string id = "3f2b12b8-2a06-45b4-b057-45949279b4e5", [FromBody] string strvalues = "Credit")
        {

            var filetext = System.IO.File.ReadAllText(pathname);
            List<ClsUser> lstUser = JsonConvert.DeserializeObject<List<ClsUser>>(filetext);

            ClsUser objectuser = (from rowobject in lstUser where rowobject.Id == id select rowobject).FirstOrDefault();
            
            lstUser.Remove(objectuser);

            objectuser.Type = strvalues;

            lstUser.Add(objectuser);

            System.IO.File.WriteAllText(@"C:\Users\Administrator\Desktop\TEST2208\UserUpdate.txt", JsonConvert.SerializeObject(lstUser));


            return Ok();


        }
        [HttpPost]
        [Route("CreateUserData")]
        
        // api/TestApi/CreateUserData
        public IHttpActionResult CreateUserData([FromBody] string objectvalues)
        {

            var filetext = System.IO.File.ReadAllText(pathname);
            List<ClsUser> lstUser = JsonConvert.DeserializeObject<List<ClsUser>>(filetext);

            ClsUser createUser = new ClsUser()
            {
                Id = "raja3f2b12b8-2a06-45b4-b057-45949279b4e5",
                ApplicationId = 1000,
                Type = "Debit",
                Summary = "Payment",
                Amount = 100,
                PostingDate = DateTime.Now,
                IsCleared = true,
                ClearedDate = DateTime.Now
            };
            lstUser.Add(createUser);
            System.IO.File.WriteAllText(@"C:\Users\Administrator\Desktop\TEST2208\UserCreate.txt", JsonConvert.SerializeObject(lstUser));


            return Ok();


        }

    }
}