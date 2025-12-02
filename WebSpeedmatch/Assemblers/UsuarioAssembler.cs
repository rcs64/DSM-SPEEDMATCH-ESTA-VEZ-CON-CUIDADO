using ApplicationCore.Domain.EN;
using WebSpeedmatch.Models;

namespace WebSpeedmatch.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel UsuarioEnToViewModel(Usuario en)
        {
            UsuarioViewModel vm = new UsuarioViewModel();
            vm.Id = en.Id;
            vm.Nombre = en.Nombre;
            vm.Email = en.Email;
            vm.Pass = en.Pass;
            vm.LikesRecibidos = en.LikesRecibidos;
            vm.LikesEnviados = en.LikesEnviados;
            vm.NumMatchs = en.NumMatchs;
            vm.Genero = en.Genero;
            vm.GeneroOtro = en.GeneroOtro;
            vm.Baneado = en.Baneado;
            vm.FechaNacimiento = en.FechaNacimiento;
            vm.FechaUltimoLogin = en.FechaUltimoLogin;
            vm.Habitos = en.Habitos;
            vm.Comportamientos = en.Comportamientos;
            vm.Hobbies = en.Hobbies;
            vm.Descripcion = en.Descripcion;
            vm.TipoPlan = en.TipoPlan;
            vm.Superlikes = en.Superlikes;
            vm.SuperlikesDisponibles = en.SuperlikesDisponibles;
            vm.PreferenciasId = en.PreferenciasId;
            return vm;
        }

        public IList<UsuarioViewModel> UsuarioEnToViewModelList(IList<Usuario> ens)
        {
            IList<UsuarioViewModel> vms = new List<UsuarioViewModel>();
            foreach (Usuario en in ens)
            {
                vms.Add(UsuarioEnToViewModel(en));
            }
            return vms;
        }
    }
}
