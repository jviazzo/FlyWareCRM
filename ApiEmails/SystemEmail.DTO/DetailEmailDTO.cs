using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEmail.DTO
{
    public class DetailEmailDTO
    {

        public int? IdEmail { get; set; }


        [StringLength(100)] // Limita la longitud a 100 caracteres
        public int? IdClient { get; set; }
      
        [StringLength(100)] // Limita la longitud a 100 caracteres
        public string? EmailDescription { get; set; }    



    }
}
