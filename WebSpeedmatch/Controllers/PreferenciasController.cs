using ApplicationCore.Domain.CEN;
using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using Infrastructure;
using Infrastructure.NHibernate;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSpeedmatch.Assemblers;
using WebSpeedmatch.Controllers;
using WebSpeedmatch.Models;

namespace WebSpeedmatch.Controllers
{
    public class PreferenciasController : BasicController
    {
        // GET: PreferenciasController
        public ActionResult Index()
        {
            SessionInitialize();
            using var session = NHibernateHelper.GetSession();
            PreferenciasRepository preferenciasRepository = new PreferenciasRepository(session);

            var ubicacionesEN = preferenciasRepository.GetAll().ToList();
            IList<Preferencias> ubicacionesENList = preferenciasRepository.GetAll().ToList();
            IEnumerable<PreferenciasViewModel> preferenciasVM = new PreferenciaAssembler().ConvertirENToViewModelList(ubicacionesEN);

            SessionClose();
            return View(preferenciasVM);
        }

        // GET: PreferenciasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PreferenciasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreferenciasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PreferenciasViewModel pref)
        {
            try
            {
                var session = NHibernateHelper.GetSession();
                PreferenciasRepository prefrep=new PreferenciasRepository(session);
                var preferencias = prefrep.GetAll().ToList();
                var unitOfWork = new UnitOfWork(session);
                var preferenciasCEN = new PreferenciasCEN(prefrep,unitOfWork);

                preferenciasCEN.Crear(pref.Orientacion, pref.Conocer, pref.OrientacionMostrar);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PreferenciasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PreferenciasController/Edit/5
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

        // GET: PreferenciasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PreferenciasController/Delete/5
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
