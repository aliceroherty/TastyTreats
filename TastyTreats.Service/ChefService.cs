using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTreats.Model.Entities;
using TastyTreats.Repository;

namespace TastyTreats.Service
{
    public class ChefService
    {
        ChefRepo repo = new ChefRepo();

        public Chef Get(int id)
        {
            return repo.Get(id);
        }
    }
}
