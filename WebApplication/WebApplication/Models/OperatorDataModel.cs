using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class OperatorDataModel : ResponseDataModel
    {
        public string dataA { get; set; }
        public string dataB { get; set; }
        public string operation { get; set; }
        public string resultvalue { get; set; }
    }
}