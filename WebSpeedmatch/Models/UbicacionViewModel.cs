using ApplicationCore.Domain.Enums;
using ApplicationCore.Domain.EN;
using System.ComponentModel.DataAnnotations;
using NHibernate.Mapping;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebSpeedmatch.Models
{
    public class UbicacionViewModel
    {
        [ScaffoldColumn(false)]
        public virtual long Id { get; set; }

        [Display(Prompt = "Dame la Latitud", Description = "Indica la Latitud de la Ubicación", Name = "LatitudUbi")]
        [Required(ErrorMessage = "La ubicación debe tener una latitud")]

        public virtual double Lat { get; set; }

        [Display(Prompt = "Dame la Longitud", Description = "Indica la Longitud de la Ubicación", Name = "LongitudUbi")]
        [Required(ErrorMessage = "La ubicación debe tener una longitud")]

        public virtual double Lon { get; set; }

        [Display(Prompt = "Dame el id del Usuario", Description = "Indica el id del usuario al que pertenece esta ubicación", Name = "IdUsuarioUbi")]
        [Required(ErrorMessage = "Se deber indicar a qué id de usuario le pertenece esta ubicación")]
        public virtual long UsuarioId { get; set; }

        [Display(Prompt = "Dame el Usuario", Description = "Devuelve los datos del Usuario al que pertenece esta Ubicación", Name = "UsuarioUbi")]
        [Required(ErrorMessage = "La ubicación debe de pertenecer a un Usuario")]
        public virtual Usuario Usuario { get; set; }

    }
}
