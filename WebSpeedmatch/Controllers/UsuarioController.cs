using Infrastructure.CP;
using ApplicationCore.Domain.EN;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.NHibernate;
using WebSpeedmatch.Models;
using WebSpeedmatch.Assemblers;

namespace WebSpeedmatch.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            SessionInitialize();
            using var session = NHibernateHelper.GetSession();

            UsuarioRepository  usuarioRepository = new UsuarioRepository(session);
            IList<Usuario> usuarios = usuarioRepository.GetAll().ToList();
            IEnumerable<UsuarioViewModel> listUser = new UsuarioAssembler().UsuarioEnToViewModelList(usuarios);

            SessionClose();
            return View(listUser);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuaroViewModel user)
        {
            try
            {
                UsuaroViewModel newUser = user();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
