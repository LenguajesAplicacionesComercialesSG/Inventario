using Inventario.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BL.GestorInventario _gestor;

        public ProductsController(BL.GestorInventario gestor)
        {
            _gestor = gestor;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var productos = _gestor.ObtenerProductos();
            return View(productos);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var producto = _gestor.ObtenerProductoPorId(id);

            return View(producto);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {

                if (!ModelState.IsValid) { 
                
                    return View(producto);
                }

                _gestor.AgregarProducto(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var producto = _gestor.ObtenerProductoPorId(id);
            return View(producto);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producto producto)
        {   
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(producto);
                }

                _gestor.ActualizarProducto(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
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
