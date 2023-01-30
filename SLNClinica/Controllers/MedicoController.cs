using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLNClinica.Data;
using SLNClinica.Models;
using System.Linq;

namespace SLNClinica.Controllers
{
    public class MedicoController : Controller
    {
        private readonly ClinicaDBContext context;

        public MedicoController(ClinicaDBContext context)
        {
            this.context = context;
        }

        //GET /medico
        //GET /medico/index
        [HttpGet]
        public IActionResult Index()
        {
            //lista de medicos
            var medicos = context.Medicos.ToList();

            //enviar los medicos a la vista
            return View(medicos);
        }

        //GET: Medico/Create
        [HttpGet]
        public ActionResult Create()
        {
            Medico medico = new Medico();

            return View("Create", medico);//devolver al cliente html(vista)
        }

        //POST: Medico/Create
        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Medicos.Add(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        // Medico/delete/1
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var medico = TraerUna(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", medico);
            }
        }

        //metodo privado
        private Medico TraerUna(int id)
        {
            return context.Medicos.Find(id);
        }

        // Medico/delete/1
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var medico = TraerUna(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                context.Medicos.Remove(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: Medico/Details/4
        [HttpGet]
        public ActionResult Details(int id)
        {
            var medico = TraerUna(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                return View("detalle", medico);
            }
        }



        //GET: medico/Edit/2
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var medico = TraerUna(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", medico);
            }
        }

        //POST: medico/Edit/2
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult EditConfirmacion(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Entry(medico).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(medico);

        }

    }
}
