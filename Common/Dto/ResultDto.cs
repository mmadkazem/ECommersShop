using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommersShop.Common.Dto
{
    public class ResultDto
    {
        public bool IsSucssecc { get ; set; }
        public string Message { get ; set; }
    }
    public class ResultDto<T>
    {
        public T Data { get; set; }
        public bool IsSucssecc { get ; set; }
        public string Message { get ; set; }
    }
    public class ResultsDto<T>
    {
        public List<T> Data { get; set; }
        public bool IsSucssecc { get ; set; }
        public string Message { get ; set; }
    }

}