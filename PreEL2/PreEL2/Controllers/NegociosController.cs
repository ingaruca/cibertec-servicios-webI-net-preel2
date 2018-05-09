using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PreEL2.Models;

namespace PreEL2.Controllers
{
    public class NegociosController : Controller
    {
        // Instancia del DBContext
        Negocios2018Entities bd = new Negocios2018Entities();

        // GET: Negocios

        // Listado de Cliente
        public ActionResult Index()
        {
            return View(bd.clientes.ToList());
        }

        // Registrar Cliente
        public ActionResult Create()
        {
            ViewBag.paises = new SelectList(bd.paises.ToList(), "Idpais", "NombrePais");

            return View(new clientes());
        }

        [HttpPost]

        public ActionResult Create(clientes objCliente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.paises = new SelectList(bd.paises.ToList(), "Idpais", "NombrePais");
                return ViewBag(objCliente);
            }

            bd.clientes.Add(objCliente);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        // Ver Detalles de Cliente
        public ActionResult Details(string id)
        {
            clientes regCli = bd.clientes.Where(c => c.IdCliente == id).First();

            return View(regCli);
        }

        // Editar Cliente
        public ActionResult Edit(string id)
        {
            clientes regCli = bd.clientes.Where(c => c.IdCliente == id).First();
            ViewBag.paises = new SelectList(bd.paises.ToList(), "Idpais", "NombrePais", regCli.IdCliente);

            return View(regCli);
        }

        [HttpPost]

        public ActionResult Edit(clientes objCliente)
        {
            if( !ModelState.IsValid)
            {
                ViewBag.paises = new SelectList(bd.paises.ToList(), "Idpais", "NombrePais", objCliente.idpais);
                return View(objCliente);
            }

            clientes regCli = bd.clientes.Where(c => c.IdCliente == objCliente.IdCliente).First();

            regCli.NomCliente = objCliente.NomCliente;
            regCli.DirCliente = objCliente.DirCliente;
            regCli.idpais = objCliente.idpais;
            regCli.fonoCliente = objCliente.fonoCliente;

            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        // Eliminar Cliente

        public ActionResult Delete(string id)
        {
            clientes regCli = bd.clientes.Where(c => c.IdCliente == id).First();

            bd.clientes.Remove(regCli);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}