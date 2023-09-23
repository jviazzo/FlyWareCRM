using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SystemEmail.DTO
{
    public class ClientDTO
    {
        public int IdClient { get; set; }

        [StringLength(100)] // Limita la longitud a 100 caracteres
        public string? Name { get; set; }

        public int? IdCategory { get; set; }

        [StringLength(100)] // Limita la longitud a 100 caracteres
        public string? CategoryDescription { get; set; }

        [StringLength(100)] // Limita la longitud a 100 caracteres
        public string? Email { get; set; }

        [StringLength(100)] // Limita la longitud a 100 caracteres
        public string? Company { get; set; }

        [StringLength(50)] // Por ejemplo, limita la longitud a 50 caracteres
        public string? Language { get; set; }

        public int? IsActive { get; set; }
    }
}

