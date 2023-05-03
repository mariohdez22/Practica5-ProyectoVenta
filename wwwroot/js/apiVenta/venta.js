
let enviarProducto = () =>
{
    let nombre = document.getElementById("nombreProducto").value;
    let precio = document.getElementById("precioProducto").value;

    document.getElementById("txtProducto").value = nombre;
    document.getElementById("txtPrecio").value = precio;
}

//---------------------------------------------------------------------------------------------------------------------------------------

const botonDetalle = document.getElementById("btnAgregarDetalle");

var num = 0

let val = 0

let AgregarDetalle = () =>
{
    //extrayendo los valores de los input para el detalle           
    let id = document.getElementById("idProducto").value;
    let Producto = document.getElementById("txtProducto").value;
    let Precio = document.getElementById("txtPrecio").value;
    let Cantidad = document.getElementById("txtCantidad").value;

    //llamando el "tbody" de la tabla y creando un "tr"
    let cuerpoTabla = document.getElementById("cuerpoTabla");
    let TR = document.createElement("tr");

    //creando los campos de la tabla donde iran los datos del detalle (visual)
    let TDProducto = document.createElement("td");
    let TDPrecio = document.createElement("td");
    let TDCantidad = document.createElement("td");
    let TDSubTotal = document.createElement("td");
    TDSubTotal.id = "tdSubtotal"
    let TDBoton = document.createElement("td");

    let botonEliminar = document.createElement("a");
    botonEliminar.innerHTML = "Eliminar"
    botonEliminar.id = "btnEliminar"
    botonEliminar.className = "btn btn-danger"
    botonEliminar.onclick = EliminarProducto

    //añadiendo los campos creados al "tr"
    TR.appendChild(TDProducto);
    TR.appendChild(TDPrecio);
    TR.appendChild(TDCantidad);
    TR.appendChild(TDSubTotal);
    TR.appendChild(TDBoton);

    //añadiendo los datos de los input a los campos de la tabla
    TDProducto.innerHTML = Producto;
    TDPrecio.innerHTML = Precio;
    TDCantidad.innerHTML = Cantidad;
    TDSubTotal.innerHTML = (parseFloat(Cantidad) * parseFloat(Precio)).toFixed(2);
    TDBoton.appendChild(botonEliminar);

    //------------------------------------------------------------------------------

    //creacion de los input hiddens

    let HiddenIndex = document.createElement("input")
    let HiddenProducto = document.createElement("input")
    let HiddenPrecio = document.createElement("input")
    let HiddenCantidad = document.createElement("input")

    HiddenIndex.name = "Detalles.Index";
    HiddenIndex.value = num;
    HiddenIndex.type = "text";

    HiddenProducto.name = "Detalles[" + num + "].Idproducto";
    HiddenProducto.value = id;
    HiddenProducto.type = "text";

    HiddenPrecio.name = "Detalles[" + num + "].Precio";
    HiddenPrecio.value = Precio;
    HiddenPrecio.type = "text";

    HiddenCantidad.name = "Detalles[" + num + "].Cantidad";
    HiddenCantidad.value = Cantidad;
    HiddenCantidad.type = "text";

    //------------------------------------------------------------------------------

    TR.appendChild(HiddenIndex);
    TR.appendChild(HiddenProducto);
    TR.appendChild(HiddenPrecio);
    TR.appendChild(HiddenCantidad);

    //agregando todo el "tr" a la tabla
    cuerpoTabla.appendChild(TR);

    //agregando la operacion de total al input total
    val += parseFloat(TDSubTotal.innerHTML)
    document.getElementById("txtTotal").value = (val).toFixed(2);

    //------------------------------------------------------------------------------

    document.getElementById("txtCantidad").value = "";
    document.getElementById("txtProducto").value = "";
    document.getElementById("txtPrecio").value = "";

    num++;

}

botonDetalle.addEventListener("click", () => {

    AgregarDetalle()

})

//---------------------------------------------------------------------------------------------------------------------------------------

let EliminarTodo = () =>
{
    const Cuerpo = document.getElementById("cuerpoTabla")

    while (Cuerpo.firstChild) {
        Cuerpo.removeChild(Cuerpo.firstChild)
    }

    //---------------------------------------

    const nuevoTotal = val * 0

    document.getElementById("txtTotal").value = (nuevoTotal).toFixed(2);
}

//---------------------------------------------------------------------------------------------------------------------------------------

let EliminarProducto = (event) =>
{
    const btnEliminar = event.target;

    const fila = btnEliminar.closest('tr');

    fila.parentNode.removeChild(fila);

    //-------------------------------------

    const subtotal = btnEliminar.parentNode.previousSibling.innerHTML

    const nuevoTotal = val -= subtotal

    document.getElementById("txtTotal").value = (nuevoTotal).toFixed(2);
}

