using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Data.Entities.DTOs
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public int StatusCode { get; set; }

    }
}
