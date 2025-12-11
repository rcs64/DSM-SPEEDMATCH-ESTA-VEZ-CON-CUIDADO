using ApplicationCore.Domain.EN;
using WebSpeedmatch.Models;
namespace WebSpeedmatch.Assemblers
{
    public class PreferenciaAssembler
    {
        public PreferenciasViewModel ConvertirENToViewModel(Preferencias en)
        {
            PreferenciasViewModel pref = new PreferenciasViewModel();
            pref.Id = en.Id;
            pref.Orientacion = en.Orientacion;
            pref.OrientacionOtro = en.OrientacionOtro;
            pref.OrientacionMostrar = en.OrientacionMostrar;
            pref.Conocer = en.Conocer;
            pref.ConocerOtro = en.ConocerOtro;
            // Obtener el usuario propietario de estas preferencias
            if (en.Usuarios != null && en.Usuarios.Count > 0)
            {
                var usuario = en.Usuarios.FirstOrDefault();
                pref.Usuario = usuario;
                pref.UsuarioId = usuario?.Id;
            }
            return pref;
        }

        public IList<PreferenciasViewModel> ConvertirENToViewModelList(IList<Preferencias> ens)
        {
            IList<PreferenciasViewModel> prefs = new List<PreferenciasViewModel>();
            foreach (Preferencias en in ens)
            {
                prefs.Add(ConvertirENToViewModel(en));
            }
            return prefs;
        }
    }
}
