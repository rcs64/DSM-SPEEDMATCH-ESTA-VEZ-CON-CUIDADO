using ApplicationCore.Domain.CEN;
using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Enums;
using ApplicationCore.Domain.Repositories;
using Infrastructure;
using Infrastructure.CP;
using Infrastructure.NHibernate;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSpeedmatch.Assemblers;
using WebSpeedmatch.Models;

namespace WebSpeedmatch.Controllers
{
    public class UbicacionController : BasicController
    {
        // GET: UbicacionController
        public ActionResult Index()
        {
            SessionInitialize();
            using var session = NHibernateHelper.GetSession();

            UbicacionRepository ubicacionRepository = new UbicacionRepository(session);
          
            var ubicacionesEN = ubicacionRepository.GetAll().ToList();
            IList<Ubicacion> ubicacionesENList = ubicacionRepository.GetAll().ToList();
            IEnumerable<UbicacionViewModel> ubicacionesVM = new UbicacionAssembler().ConvertirENToViewModelList(ubicacionesEN);

            SessionClose();
            return View(ubicacionesVM);
        }

        // GET: UbicacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UbicacionController/Create
        public ActionResult Create()
        {
            SessionInitialize();
            using var session = NHibernateHelper.GetSession();

            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            var usuarios = usuarioRepository.GetAll().ToList();

            var usuarioSelectList = new SelectListItem[usuarios.Count];
            for (int i = 0; i < usuarios.Count; i++)
            {
                usuarioSelectList[i] = new SelectListItem
                {
                    Value = usuarios[i].Id.ToString(),
                    Text = usuarios[i].Nombre
                };
            }

            ViewBag.Usuarios = usuarioSelectList;
            SessionClose();

            return View();
        }

        // POST: UbicacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UbicacionViewModel ubi)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Recargar usuarios si hay errores de validación
                    SessionInitialize();
                    using var sessionGetUsers = NHibernateHelper.GetSession();
                    UsuarioRepository usuarioRepositoryGetUsers = new UsuarioRepository(sessionGetUsers);
                    var usuarios = usuarioRepositoryGetUsers.GetAll().ToList();

                    var usuarioSelectList = new SelectListItem[usuarios.Count];
                    for (int i = 0; i < usuarios.Count; i++)
                    {
                        usuarioSelectList[i] = new SelectListItem
                        {
                            Value = usuarios[i].Id.ToString(),
                            Text = usuarios[i].Nombre
                        };
                    }

                    ViewBag.Usuarios = usuarioSelectList;
                    SessionClose();
                    return View(ubi);
                }

                SessionInitialize();
                var session = NHibernateHelper.GetSession();
                UbicacionRepository ubicacionRepository = new UbicacionRepository(session);
                var unitOfWork = new UnitOfWork(session);
                var usuarioRepo = new UsuarioRepository(session);
                var ubicacionCEN = new UbicacionCEN(ubicacionRepository, usuarioRepo, unitOfWork);

                ubicacionCEN.Crear(ubi.Lat, ubi.Lon, ubi.UsuarioId);
                SessionClose();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SessionClose();
                ModelState.AddModelError("", $"Error al crear la ubicación: {ex.Message}");
                
                // Recargar usuarios para mostrar la forma de nuevo
                SessionInitialize();
                using var sessionGetUsers = NHibernateHelper.GetSession();
                UsuarioRepository usuarioRepositoryGetUsers = new UsuarioRepository(sessionGetUsers);
                var usuarios = usuarioRepositoryGetUsers.GetAll().ToList();

                var usuarioSelectList = new SelectListItem[usuarios.Count];
                for (int i = 0; i < usuarios.Count; i++)
                {
                    usuarioSelectList[i] = new SelectListItem
                    {
                        Value = usuarios[i].Id.ToString(),
                        Text = usuarios[i].Nombre
                    };
                }

                ViewBag.Usuarios = usuarioSelectList;
                SessionClose();
                return View(ubi);
            }
        }

        // GET: UbicacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UbicacionController/Edit/5
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

        // GET: UbicacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UbicacionController/Delete/5
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
