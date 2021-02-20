using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExamSiemens.Models
{
    public class BaseModel
    {
        public bool ExistError { get; set; }
        public string Error { get; set; }
        public bool IsOk { get; set; }
    }
}