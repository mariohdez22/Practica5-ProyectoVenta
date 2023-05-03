﻿using System;
using System.Collections.Generic;

namespace Practica5_ProyectoVenta.Models;

public partial class Ventum
{
    public int Idventa { get; set; }

    public string CodigoVenta { get; set; } = null!;

    public int Idcliente { get; set; }

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Cliente IdclienteNavigation { get; set; } = null!;
}
