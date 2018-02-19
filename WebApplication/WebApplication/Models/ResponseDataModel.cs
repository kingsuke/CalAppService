using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ResponseDataModel
    {
        public string Status { get; set; }
        public string Messsage { get; set; }
        public object Model { get; set; }
    }
}