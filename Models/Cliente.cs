using System;
using System.Collections.Generic;

namespace Practica5_ProyectoVenta.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
