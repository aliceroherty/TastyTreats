using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyTreats.Model.DTO
{
    public class ReviewDTO
    {
        public int ID { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public int Stars { get; set; }

    }
}
