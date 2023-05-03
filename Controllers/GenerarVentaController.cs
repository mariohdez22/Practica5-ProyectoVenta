using Microsoft.AspNetCore.Mvc;
using Practica5_ProyectoVenta.Models;
using Practica5_ProyectoVenta.Models.ViewModel;
#pragma warning disable

namespace Practica5_ProyectoVenta.Controllers
{
    public class GenerarVentaController : Controller
    {
        private readonly ProyectoVentaContext _venta;

        public GenerarVentaController(ProyectoVentaContext venta)
        {
            _venta = venta;
        }

        public IActionResult IndexVenta()
        {
            return View();
        }

        [HttpGet]
        public IActionResult buscarProducto(string busqueda) 
        {
            VentaVM venta = new VentaVM() 
            { 
                Productos = _venta.Productos
                .Where(b => b.Producto1!.Contains(busqueda))
                .Select(b => new ProductosVM() 
                { 
                
                    Idproducto = b.Idproducto,
                    Producto1 = b.Producto1,
                    Marca = b.Marca,
                    Precio = b.Precio,
                    Cantidad = b.Cantidad

                }).ToList()
            };

            return Json(new {datos = venta});   
        }

        [HttpPost]
        public IActionResult GenerarCompra(VentaVM oVentaVM) 
        {

            try
            {
                Ventum ventum = new Ventum();
                ventum.CodigoVenta = oVentaVM.CodigoVenta;
                ventum.Idcliente = oVentaVM.Idcliente;
                ventum.Total = oVentaVM.Total;
                ventum.Fecha = DateTime.Now;
                _venta.Add(ventum);
                _venta.SaveChanges();

                foreach (var vm in oVentaVM.Detalles)
                {
                    DetalleVentum dv = new DetalleVentum();
                    dv.Idventa = ventum.Idventa;
                    dv.Idproducto = vm.Idproducto;
                    dv.Precio = vm.Precio;
                    dv.Cantidad = vm.Cantidad;
                    dv.Subtotal = vm.Cantidad * vm.Precio;

                    var producto = _venta.Productos.Find(vm.Idproducto);
                    producto.Cantidad -= vm.Cantidad;
                    
                    _venta.Productos.Update(producto);
                    _venta.DetalleVenta.Add(dv);

                }

                _venta.SaveChanges();

                return RedirectToAction(nameof(IndexVenta));

            }
            catch (Exception)
            {

                return View(oVentaVM);
                
            }

        }

    }
}
