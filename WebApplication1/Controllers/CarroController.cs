﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            Carro.GerarLista(Session);
            return View(Session["ListaCarro"] as List<Carro>);
        }

        public ActionResult Exibir(int id)
        {
            return View((Session["ListaCarro"] as List<Carro>).ElementAt(id));
        }

        public ActionResult Delete(int id)
        {
            return View((Session["ListaCarro"] as List<Carro>).ElementAt(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Carro carro)
        {
            Carro.Procurar(Session, id)?.Excluir(Session);

            return RedirectToAction("Listar");
        }
        public ActionResult Edit(int id)
        {
            return View(Carro.Procurar(Session, id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Carro carro)
        {
            carro.Editar(Session, id);

            return RedirectToAction("Listar");
        }
        public ActionResult Create()
        {
            return View(new Carro());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carro carro)
        {
            carro.Adicionar(Session);

            return RedirectToAction("Listar");
        }
    }
}