using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEmail.DTO
{
    public class DashBoardDTO
    {
        public int TotalEmails { get; set; }    

        public List<WeekEmailDTO>? LastWeekEmails { get; set; }  

    }
}
