using Dapper.Contrib.Extensions;
using rest_api.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace rest_api.Entities
{
    [Table("td_menu")]
    public class TDMenu : BaseEntity
    {
        [ExplicitKey]//[Key]
        public string menu_code {get;set;}
        public string parent_code {get;set;}
        public string screen_code {get;set;}
        public string assembly_name {get;set;}
        public string parameter {get;set;}
        public int device_type {get;set;}
        public bool auto_start {get;set;}
    }
}
