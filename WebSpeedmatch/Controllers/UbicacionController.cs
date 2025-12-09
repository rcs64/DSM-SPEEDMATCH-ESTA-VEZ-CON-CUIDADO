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
            return View();
        }

        // POST: UbicacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UbicacionViewModel ubi)
        {
            try
            {
                var session = NHibernateHelper.GetSession();
                UbicacionRepository ubicacionRepository=new UbicacionRepository(session);
                var unitOfWork = new UnitOfWork(session);
                var usuarioRepo = new UsuarioRepository(session);
                var ubicacionCEN = new UbicacionCEN(ubicacionRepository,usuarioRepo, unitOfWork);

                ubicacionCEN.Crear(ubi.Lat, ubi.Lon, ubi.UsuarioId);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
