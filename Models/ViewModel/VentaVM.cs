namespace Practica5_ProyectoVenta.Models.ViewModel
{
    public class VentaVM
    {
        public string CodigoVenta { get; set; } = null!;

        public int Idcliente { get; set; }

        public decimal Total { get; set; }

        public List<DetalleVM> Detalles { get; set;}

        public List<ProductosVM> Productos { get; set;}
    }
}
