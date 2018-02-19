using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CalAppController : ApiController
    {
        [HttpPost]
        public object SaveFile(string dataTxt, string fileName)
        {
            try
            {
                byte[] f = Encoding.ASCII.GetBytes(dataTxt);
                MemoryStream ms = new MemoryStream(f);
                FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath
                            (@"~/SaveFolder/") + fileName, FileMode.Create);
                ms.WriteTo(fs);
                ms.Close();
                fs.Close();
                fs.Dispose();
                var res = new ResponseDataModel { Status = "OK" };
                var jsonObject = JsonConvert.SerializeObject(res);
                return jsonObject;

            }
            catch (Exception ex)
            {
                var res = new ResponseDataModel { Status = "FAILED", Messsage = ex.Message.ToString() };
                var jsonObject = JsonConvert.SerializeObject(res);
                return jsonObject;
            }
        }
        
        [HttpGet]
        public object LoadFile()
        {
            try
            {
                string allText = System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath
                           (@"~/SaveFolder/") + "kingsuke");
                object jsonObject = JsonConvert.DeserializeObject(allText);
                var res = new ResponseDataModel { Status = "OK",Model = jsonObject };
                var jsonRes = JsonConvert.SerializeObject(res);
                return jsonRes;
               
            }
            catch(Exception ex)
            {
                var res = new ResponseDataModel { Status = "FAILED", Messsage = ex.Message.ToString() };
                var jsonObject = JsonConvert.SerializeObject(res);
                return jsonObject;
            }
           
        }
    }
}
