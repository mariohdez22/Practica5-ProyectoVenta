using System;
using System.Collections.Generic;

namespace Practica5_ProyectoVenta.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Producto1 { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
