using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.EntityModels
{
    public class BaseEntity
    {
        public string description { get; set; }
        public string device_no { get; set; }
        public string device_id { get; set; }
        public int source_platform { get; set; }
        public int source_program { get; set; }
        public string create_user { get; set; }
        public DateTime create_date { get; set; }
        public string update_user { get; set; }
        public DateTime update_date { get; set; }
        public int status { get; set; }
    }
}
