﻿using System.ComponentModel.DataAnnotations;

namespace Vehicles.DTOs
{
    public class VehicleTypeCreationDTO
    {
        [Display(Name = "Tipo de vehículo")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
    }
}
