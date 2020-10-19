using CRUDProdutos.Context;
using CRUDProdutos.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
 
namespace CRUDProdutos.Controllers
{
    public class ProdutosController : Controller
    {

        DbContextProduto db;

        public ProdutosController ()
        {
            db = new DbContextProduto();
        }

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = db.Produto.ToList();

            double valorTotal = 0;

            foreach (var produto in produtos)
            {
                if (produto.idPromocao == 1) //Leve 2 e Pague 1
                {
                    int qtdPromo1 = produto.quantidade % 2 != 0 ? produto.quantidade : produto.quantidade / 2;
                    
                    valorTotal += qtdPromo1 * produto.preco;
                }

                if (produto.idPromocao == 2) //3 por R$ 10,00
                {
                    int qtdPromo2 = produto.quantidade % 3 != 0 ? produto.quantidade : produto.quantidade / 3;

                    valorTotal += qtdPromo2 * 10;
                }
                if (produto.idPromocao == 3) //Produtos sem promoção
                    valorTotal += produto.quantidade * produto.preco;              
            }

            ViewData["valorTotal"] = String.Format("{0:C}", valorTotal);

            return View(produtos);
        }

        public ActionResult Create()
        {
            ViewBag.Promocao = db.Promocao;
            var model = new ProdutoViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto();
                produto.nome = model.nome;
                produto.quantidade = model.quantidade;
                produto.preco = model.preco;
                produto.idPromocao = model.idPromocao;
                
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Se ocorrer um erro retorna para pagina
            ViewBag.Promocao = db.Promocao;
            return View(model);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Produto produto = db.Produto.Find(id);

            if (produto == null)            
                return HttpNotFound();            

            ViewBag.Promocao = db.Promocao;
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,quantidade,preco,idPromocao")] Produto model)
        {
            if (ModelState.IsValid)
            {
                var produto = db.Produto.Find(model.id);

                if (produto == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                produto.nome = model.nome;
                produto.quantidade = model.quantidade;
                produto.preco = model.preco;
                produto.idPromocao = model.idPromocao;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Promocao = db.Promocao;
            return View(model);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Produto produto = db.Produto.Find(id);

            if (produto == null)            
                return HttpNotFound();
            
            ViewBag.Promocao = db.Promocao.Find(produto.idPromocao).descricao;

            return View(produto);
        }
        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produto.Find(id);

            db.Produto.Remove(produto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Produto produto = db.Produto.Find(id);

            if (produto == null)            
                return HttpNotFound();            

            ViewBag.Promocao = db.Promocao.Find(produto.idPromocao).descricao;

            return View(produto);
        }
    }
}