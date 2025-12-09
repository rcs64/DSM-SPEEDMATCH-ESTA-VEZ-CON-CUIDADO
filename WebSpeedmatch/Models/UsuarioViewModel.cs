using ApplicationCore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebSpeedmatch.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Prompt = "Introduce tu nombre", Name = "Nombre")]
        [Required(ErrorMessage = "El nombre no puede estar vacío")]
        [StringLength(maximumLength: 60, MinimumLength = 2, ErrorMessage = "El nombre no puede ser mayor de 60 caracteres ni menor que 2 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Introduce tu email", Name = "Email")]
        [Required(ErrorMessage = "Necesitas escribir un correo electrónico")]
        [StringLength(maximumLength: 80, MinimumLength = 3, ErrorMessage = "El email no puede ser mayor de 80 caracteres ni menor que 3 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Introduce tu contraseña", Name = "Pass")]
        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        [StringLength(maximumLength: 60, MinimumLength = 8, ErrorMessage = "La contraseña no puede ser mayor de 60 caracteres ni menor que 8 caracteres")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@._*!?\-])[A-Za-z\d@._*!?\-]{8,}$",
        ErrorMessage = "La contraseña debe tener mínimo 8 caracteres, una mayúscula, una minúscula, un número y un símbolo permitido (@ . - _ * ! ?).")]
        public string Pass { get; set; } // no deberia ser private? lo he copiado conforme lo hizo en su momento el LLM


        [Display(Name = "Likes")]
        public int LikesRecibidos { get; set; }

        [Display(Name = "Likes enviados")]
        public int LikesEnviados { get; set; }

        [Display(Name = "Número de match")]
        public int NumMatchs { get; set; }

        [Display(Name = "Género")]
        [Required(ErrorMessage = "Elige un género o elige 'otro' para indicar uno que no aparece")]
        public Genero Genero { get; set; }

        [Display(Prompt = "Introduce un género que no aparece entre el listado", Name = "Otro género")]
        [StringLength(maximumLength: 60, ErrorMessage = "Rellena este campo con un género de máximo 60 caracteres")]
        public string? GeneroOtro { get; set; }

        [Display(Name = "Baneado")]
        public bool Baneado { get; set; }

        [Display(Prompt = "Introduce tu fecha de nacimiento (opcional)", Name = "Fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Último login")]
        public DateTime? FechaUltimoLogin { get; set; }

        [Display(Prompt = "Introduce tus hábitos (opcional)", Name = "Hábitos")]
        [StringLength(maximumLength: 60)]
        public string? Habitos { get; set; }

        [Display(Prompt = "Introduce tus comportamientos (opcional)", Name = "Comportamientos")]
        [StringLength(maximumLength: 60)]
        public string? Comportamientos { get; set; }

        [Display(Prompt = "Introduce tus hobbies (opcional)", Name = "Hobbies")]
        [StringLength(maximumLength: 60)]
        public string? Hobbies { get; set; }

        [Display(Prompt = "Descríbete (opcional)", Name = "Descripción")]
        [StringLength(maximumLength: 120)]
        public string? Descripcion { get; set; }

        [Display(Name = "Tipo de plan")]
        public Plan TipoPlan { get; set; } // si no se le asigna nada se autoasigna a gratuito


        [Display(Name = "Superlikes enviados")]
        public int Superlikes { get; set; }

        [Display(Name = "Superlikes disponibles")]
        public int SuperlikesDisponibles { get; set; }

        [Display(Name = "Clave ajena a preferencias")]
        public long? PreferenciasId { get; set; }

        // falta la parte de relaciones, que no se si va aqui
    }
}
