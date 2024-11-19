﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pais")] //Para identificar el nombre de la propiedad mas fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")] //Longitud max
        [Required(ErrorMessage = "Es campo {0} obligatorio")] //Campo obligatorio
        public string Name { get; set; }
    }
}
