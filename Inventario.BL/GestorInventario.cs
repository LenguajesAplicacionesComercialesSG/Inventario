namespace Inventario.BL
{
    public class GestorInventario
    {
        private List<MODEL.Producto> listaProductos;

        public GestorInventario()
        {
            // Se inicializa la lista correctamente con objetos de tipo MODEL.Producto
            listaProductos = new List<MODEL.Producto>() { 
                new MODEL.Producto { Id = 1, Nombre = "Laptop", Categoria = "Tecnología", Precio = 999.99, Stock = 10 },
                new MODEL.Producto { Id = 2, Nombre = "Smartphone", Categoria = "Papelería", Precio = 499.99, Stock = 20 },
                new MODEL.Producto { Id = 3, Nombre = "Cámara", Categoria = "Tecnología", Precio = 299.99, Stock = 15 },

            };
        }

        public void AgregarProducto(MODEL.Producto producto)
        {
            listaProductos.Add(producto);
        }

        public void EliminarProducto(int idProducto)
        {
            var producto = listaProductos.FirstOrDefault(p => p.Id == idProducto);
            if (producto != null)
            {
                listaProductos.Remove(producto);
            }
        }

        public List<MODEL.Producto> BuscarProductosPorNombre(string nombreProducto)
        {
            var productosEncontrados = listaProductos.Where(p => p.Nombre.ToLower().Contains(nombreProducto.ToLower()) || p.Categoria.ToLower().Contains(nombreProducto.ToLower())
                ).ToList();
           
            return productosEncontrados;
        }

        public List<MODEL.Producto> BuscarProductosPorCategoria(string categoriaProducto)
        {
            var productosPorCategoria = listaProductos.Where(p => p.Categoria.Equals(categoriaProducto, StringComparison.OrdinalIgnoreCase)).ToList();
            return productosPorCategoria;
        }

        public List<MODEL.Producto> ObtenerProductos()
        {
            return listaProductos.ToList();
            
        }

    }
}
