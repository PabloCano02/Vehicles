using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vehicles.Entities
{
    public class Detail
    {
        public int Id { get; set; }

        public int HistoryId { get; set; }

        public int ProcedureId { get; set; }

        [Display(Name = "Historia")]
        [JsonIgnore]
        public History History { get; set; }

        [Display(Name = "Procedimiento")]
        [JsonIgnore]
        public Procedure Procedure { get; set; }

        [Display(Name = "Precio Mano de Obra")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int LaborPrice { get; set; }

        [Display(Name = "Precio Repuestos")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int SparePartsPrice { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public int TotalPrice => LaborPrice + SparePartsPrice;

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}
