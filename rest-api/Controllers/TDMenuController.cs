using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using rest_api.DAL;
using rest_api.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rest_api.Controllers
{
    [Route("api")]
    public class TDMenuController : Controller
    {
        ITDMenuRespository itdmenu;

        public TDMenuController(IConfiguration Configuration)
        {
            itdmenu = new TDMenuRespository(Configuration);
        }

        [Route("menus")]
        [HttpGet]
        public List<TDMenu> GetTDMenus()
        {
            var tmp = itdmenu.GetTDMenus(10, 0, "menu_code", true);
            return tmp;
        }

        [Route("menus/{limit}/{offset}/{sortname}/{sort}")]
        [HttpGet]
        public List<TDMenu> GetTDMenus(int limit, int offset, string sortname, string sort)
        {
            var tmp = itdmenu.GetTDMenus(limit, offset, sortname, sort == "asc");
            return tmp;
        }

        [Route("menu/{id}")]
        [HttpGet]
        public TDMenu GetSingleTDMenu(string id)
        {
            var tmp = itdmenu.GetSingleTDMenu(id);
            if (tmp == null) tmp = new TDMenu();
            return tmp;
        }

        [Route("menu/{id}")]
        [HttpDelete]
        public bool DeleteTDMenu(string id)
        { 
            var tmp = itdmenu.DeleteTDMenu(id);
            return tmp;
        }

        [Route("menu")]
        [HttpPost]
        public bool InsertTDMenu([FromBody]TDMenu ourTDMenu)
        {
            var tmp = itdmenu.InsertTDMenu(ourTDMenu);
            return tmp;
        }

        [Route("menu")]
        [HttpPut]
        public bool UpdateTDMenu([FromBody]TDMenu ourTDMenu)
        {
            var tmp = itdmenu.UpdateTDMenu(ourTDMenu);
            return tmp;
        }
    }
}
