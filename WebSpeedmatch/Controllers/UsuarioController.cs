using Infrastructure.CP;
using ApplicationCore.Domain.EN;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.NHibernate;
using WebSpeedmatch.Models;
using WebSpeedmatch.Assemblers;
using Infrastructure;
using ApplicationCore.Domain.CEN;
using ApplicationCore.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.Generos = Enum.GetValues(typeof(Genero))
                .Cast<Genero>()
                .Select(g => new SelectListItem
                {
                    Value = ((int)g).ToString(),
                    Text = g.ToString()
                }).ToList();

            ViewBag.Planes = Enum.GetValues(typeof(Plan))
                .Cast<Plan>()
                .Select(p => new SelectListItem
                {
                    Value = ((int)p).ToString(),
                    Text = p.ToString()
                }).ToList();
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel user)
        {
            try
            {
                var session = NHibernateHelper.GetSession();
                var usuarioRepository = new UsuarioRepository(session);
                var unitOfWork = new UnitOfWork(session);
                var usuarioCEN = new UsuarioCEN(usuarioRepository, unitOfWork);

                usuarioCEN.Crear(user.Nombre,  user.Email, user.Pass, user.TipoPlan);

                return RedirectToAction("Index");
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
