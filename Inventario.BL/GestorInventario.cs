using Inventario.DA;
using Inventario.MODEL;

namespace Inventario.BL
{
    public class GestorInventario
    {
        private readonly AppDbContext _db;


        public GestorInventario(AppDbContext context)
        {
            _db = context;
        }

        // Método para agregar un nuevo producto al inventario
        public void AgregarProducto(MODEL.Producto producto)
        {
            _db.Productos.Add(producto);
            _db.SaveChanges();
        }

        public void ActualizarProducto(MODEL.Producto producto)
        {
            var productoExistente = _db.Productos.Find(producto.Id);
            if (productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Categoria = producto.Categoria;
                productoExistente.Precio = producto.Precio;
                productoExistente.Stock = producto.Stock;
                _db.SaveChanges();
            }
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            return _db.Productos.Find(idProducto);
        }

        // Metodo para eliminar producto
        public void EliminarProducto(int idProducto)
        {
            var producto = _db.Productos.Find(idProducto);
            if (producto != null)
            {
                _db.Productos.Remove(producto);
                _db.SaveChanges();
            }
        }

        public List<MODEL.Producto> BuscarProductosPorNombre(string nombreProducto)
        {
            var productosEncontrados = _db.Productos.Where(p => p.Nombre.ToLower().Contains(nombreProducto.ToLower()) || p.Categoria.ToLower().Contains(nombreProducto.ToLower())
                ).ToList();
           
            return productosEncontrados;
        }

        public List<MODEL.Producto> BuscarProductosPorCategoria(string categoriaProducto)
        {
            var productosPorCategoria = _db.Productos.Where(p => p.Categoria.Equals(categoriaProducto, StringComparison.OrdinalIgnoreCase)).ToList();
            return productosPorCategoria;
        }

        public List<MODEL.Producto> ObtenerProductos()
        {
            return _db.Productos.ToList();
            
        }

    }
}
