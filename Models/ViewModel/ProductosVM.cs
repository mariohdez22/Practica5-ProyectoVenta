namespace Practica5_ProyectoVenta.Models.ViewModel
{
    public class ProductosVM
    {
        public int Idproducto { get; set; }

        public string Producto1 { get; set; } = null!;

        public string Marca { get; set; } = null!;

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}
