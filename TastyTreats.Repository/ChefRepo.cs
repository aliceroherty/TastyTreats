using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTreats.Model.Entities;
using Types;

namespace TastyTreats.Repository
{
    public class ChefRepo
    {
        DataAccess db = new DataAccess();

        public Chef Get(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@ID", id, SqlDbType.Int)
            };

            DataTable dt = db.Execute("Chef_GetById", parms);

            if (dt.Rows.Count == 1)
            {
                return UnpackChef(dt.Rows[0]);
            }

            return null;
        }

        private Chef UnpackChef(DataRow row)
        {
            return new Chef
            {
                ID = Convert.ToInt32(row["ChefId"]),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                TypeID = Convert.ToInt32(row["ChefTypeId"])
            };
        }
    }
}
