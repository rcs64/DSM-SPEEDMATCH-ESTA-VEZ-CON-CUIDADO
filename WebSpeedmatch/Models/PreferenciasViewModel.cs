using ApplicationCore.Domain.Enums;
using ApplicationCore.Domain.EN;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebSpeedmatch.Models
{
    public class PreferenciasViewModel
    {
        [ScaffoldColumn(false)]
        public virtual long Id { get; set; }

        [Display(Prompt = "Dame la orientacion", Description = "Indica la orientación sexual del usuario", Name = "Orientacion")]
        [Required(ErrorMessage = "El usuario debe especificar una orientación sexual")]
        public virtual OrientacionSexual Orientacion { get; set; }

        [Display(Prompt = "Dame la otra orientación", Description = "Indica la otra orientación del usuario, si éste ha especificado alguna", Name = "OtraOrientacion")]
        public virtual string OrientacionOtro { get; set; }

        [Display(Prompt = "Dime si el usuario quiere mostrar su orientación sexual", Description = "Indica si el usuario desea mostrar su orientación sexual", Name = "MostrarOrientación")]
        [Required(ErrorMessage = "El usaurio debe indicar si quiere mostrar su orientación sexual o no")]
        public virtual bool OrientacionMostrar { get; set; }

        [Display(Prompt = "Dame la preferencia de que sexo desea el usuario conocer", Description = "Indica la preferencia de sexo para conocer de un usuario", Name = "Conocersexo")]
        [Required(ErrorMessage = "El usuario debe especificar una preferencia de cual sexo desea conocer")]
        public virtual PrefConocer Conocer { get; set; }

        [Display(Prompt = "Dame la otra preferencia de sexo para conocer", Description = "Indica la otra preferencia de sexo para conocer, si el usuario ha especificado alguna", Name = "OtraPreferenciaSexo")]
        public virtual string ConocerOtro { get; set; }


        // Reverse relation
        [Display(Prompt = "Dame el usuario", Description = "Indica el usuario al que pertenecen estas preferencias", Name = "UsuarioPreferencia")]
        public virtual long? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
