using ApplicationCore.Domain.EN;
using WebSpeedmatch.Models;

namespace WebSpeedmatch.Assemblers
{
    public class UbicacionAssembler
    {
        public UbicacionViewModel ConvertirENToViewModel(Ubicacion en)
        {
            UbicacionViewModel ubi = new UbicacionViewModel();
            ubi.Id = en.Id;
            ubi.Lat = en.Lat;
            ubi.Lon = en.Lon;
            ubi.UsuarioId = en.UsuarioId;
            ubi.Usuario = en.Usuario;
            return ubi;
        }
    

        public IList<UbicacionViewModel> ConvertirENToViewModelList(IList<Ubicacion> ens)
            {
                IList<UbicacionViewModel> ubis = new List<UbicacionViewModel>();
                foreach (Ubicacion en in ens)
                {
                    ubis.Add(ConvertirENToViewModel(en));
                }
                return ubis;
        }
    }
}
