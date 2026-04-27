using Inventario.BL;

namespace Inventario.Tests
{
    public class GestionInventario
    {
        [Fact]
        public void Se_Puede_Agregar_Un_Producto()
        {
            MODEL.Producto nuevoProducto = new MODEL.Producto { Id = 4, Nombre = "Tablet", Categoria = "Tecnología", Precio = 199.99, Stock = 30 };
            GestorInventario gestor = new GestorInventario();
         


            gestor.AgregarProducto(nuevoProducto);


            var productos = gestor.ObtenerProductos();

            Assert.Contains(nuevoProducto, productos);

        }

        [Fact]
        public void Se_Puede_Eliminar_Un_Producto()
        {
            int idProductoAEliminar = 2;
            GestorInventario gestor = new GestorInventario();


            gestor.EliminarProducto(idProductoAEliminar);


            var productos = gestor.ObtenerProductos();
            Assert.DoesNotContain(productos, p => p.Id == idProductoAEliminar);
        }

        [Fact]
        public void Se_Puede_Buscar_Producto_Por_Nombre()
        {
            string nombreProducto = "Laptop";
            GestorInventario gestor = new GestorInventario();

            MODEL.Producto nuevoProducto = new MODEL.Producto
            {
                Id = 4,
                Nombre = "Laptop",
                Categoria = "Tecnología",
                Precio = 199.99,
                Stock = 30
            };

            gestor.AgregarProducto(nuevoProducto);


            var productosEncontrados = gestor.BuscarProductosPorNombre(nombreProducto);


            Assert.NotEmpty(productosEncontrados);
            Assert.All(productosEncontrados, p => Assert.Contains(nombreProducto, p.Nombre));
        }

        [Fact]
        public void Se_Puede_Buscar_Producto_Por_Categoria()
        {
            string categoriaProducto = "Tecnología";
            GestorInventario gestor = new GestorInventario();

            MODEL.Producto nuevoProducto = new MODEL.Producto
            {
                Id = 4,
                Nombre = "Tablet",
                Categoria = "Tecnología",
                Precio = 199.99,
                Stock = 30
            };

            gestor.AgregarProducto(nuevoProducto);

            var productosPorCategoria = gestor.BuscarProductosPorCategoria(categoriaProducto);

            Assert.NotEmpty(productosPorCategoria);
            Assert.All(productosPorCategoria, p => Assert.Equal(categoriaProducto, p.Categoria));
        }
    }
}
