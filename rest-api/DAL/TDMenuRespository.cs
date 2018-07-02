using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using rest_api.Entities;


namespace rest_api.DAL
{
    public class TDMenuRespository : ITDMenuRespository
    {
        public TDMenuRespository(IConfiguration Configuration)
        {
            var tmp = Configuration["ConnectionStrings:localDb"];
            db = new NpgsqlConnection(tmp);
        }

        private readonly IDbConnection db;
        TDMenu ITDMenuRespository.GetSingleTDMenu(string tdMenuId)
        {
            var rowAffect = db.Get<TDMenu>(tdMenuId);
            return rowAffect;
        }

        List<TDMenu> ITDMenuRespository.GetTDMenus(int limit, int offset, string sortname, bool sort)
        {
            // @sort
            var sql = "select * from td_menu order by @sortname limit @limit offset @offset";
            var asc = sortname + " " +(sort ? "asc" : "desc");
            var tmp = db.Query<TDMenu>(sql, new { sortname = asc, offset, limit}).ToList();
            return tmp;
        }

        bool ITDMenuRespository.DeleteTDMenu(string tdMenuId)
        {
            var tmp = db.Get<TDMenu>(tdMenuId);
            bool rowAffect = this.db.Delete(tmp);

            return rowAffect;
        }

        bool ITDMenuRespository.InsertTDMenu(TDMenu ourTDMenu)
        {
            int rowsAffected = (int)this.db.Insert(ourTDMenu);
            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        bool ITDMenuRespository.UpdateTDMenu(TDMenu ourTDMenu)
        {
            bool rowsAffect = this.db.Update(ourTDMenu);

            return rowsAffect;
        }
    }
}
