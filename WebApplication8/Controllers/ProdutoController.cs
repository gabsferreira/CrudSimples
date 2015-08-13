using CrudSimples.BLL;
using CrudSimples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudSimples.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            BLLProduto bll = new BLLProduto();
            List<Produto> produtos = bll.Lista();
            return View(produtos);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Produto usuario)
        {
            BLLProduto bll = new BLLProduto();
            bll.Adiciona(usuario);
            return RedirectToAction("index");
        }

        public ActionResult Edita(int id)
        {
            BLLProduto bll = new BLLProduto();
            Produto produto = bll.BuscaPorId(id);

            return View(produto);
        }

        public ActionResult Altera(Produto usuario)
        {
            BLLProduto bll = new BLLProduto();
            bll.Altera(usuario);
            return RedirectToAction("index");
        }

        public ActionResult Exclui(int id)
        {
            BLLProduto bll = new BLLProduto();
            bll.Exclui(id);

            return RedirectToAction("index");
        }
    }
}