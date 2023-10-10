using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj02N.Models;
using Proj02N.Dados;

namespace Proj02N.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {            
            return View(Repositorio.ListarClientes());
        }

        [HttpGet]
        [Authorize]
        public ActionResult AlterarCliente(int id)
        {
            return View(Repositorio.BuscarCliente(id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult AlterarCliente(Clientes Novo)
        {
            Repositorio.AlterarCliente(Novo);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult IncluirCliente()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult IncluirCliente(Clientes Novo)
        {
            Repositorio.NovoCliente(Novo);
            return RedirectToAction("index");
        }

        [Authorize]
        public ActionResult VerPedidos(int id)
        {
            Session["Cliente"] = id;
            return View(Repositorio.ListarPedidos(id));
        }

        [HttpGet]
        [Authorize]
        public ActionResult IncluirPedido()
        {
            Pedidos Novo = new Pedidos();
            Novo.CodCliente = Convert.ToInt32(Session["Cliente"].ToString());
            return View(Novo);
        }

        [HttpPost]
        [Authorize]
        public ActionResult IncluirPedido(Pedidos Novo)
        {
            Repositorio.NovoPedido(Novo);
            return RedirectToAction("VerPedidos/" + 
                                     Session["Cliente"].ToString());
        }

        [HttpGet]
        [Authorize]
        public ActionResult ApagarPedido(int id)
        {
            Pedidos Apagar = new Pedidos();
            Apagar.CodCliente = 
                  Convert.ToInt32(Session["Cliente"].ToString());
            Apagar.CodPedido = id;

            Repositorio.ApagarPedido(Apagar);
            return RedirectToAction("VerPedidos/" +
                                     Session["Cliente"].ToString());
        }
    }
}