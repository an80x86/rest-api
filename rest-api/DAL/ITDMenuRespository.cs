using rest_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.DAL
{
    internal interface ITDMenuRespository
    {
        List<TDMenu> GetTDMenus(int limit, int offset, string sortname, bool sort);

        TDMenu GetSingleTDMenu(string tdMenuId);

        bool InsertTDMenu(TDMenu ourTDMenu);

        bool DeleteTDMenu(string tdMenuId);

        bool UpdateTDMenu(TDMenu ourTDMenu);
    }
}