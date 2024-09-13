public class Cadeteria : IData
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;
    private List<Pedido> pedidos;

    private static int cont = 1;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.cadetes = new List<Cadete>();
        this.pedidos = new List<Pedido>();
    }

    public void CargarCadete(string nombre, string cedula, string telefono)
    {
        this.cadetes.Add(new Cadete(cont.ToString(), nombre, cedula, telefono));
        cont++;
    }

    public void CargarPedido(string obs, string nombre, string direccion, string telefono, string referenciaDireccion)
    {
        this.pedidos.Add(new Pedido(obs, nombre, direccion, telefono, referenciaDireccion));
    }

    public string ObtenerDatos()
    {
        return $"Nombre: {this.nombre}, Telefono: {this.telefono}";
    }
    
    // public IReadOnlyList<Pedido> ListaPedidos()
    // {
    //     return this.pedidos.AsReadOnly();
    // }
    // public IReadOnlyList<Cadete> ListaCadetes()
    // {
    //     return this.cadetes.AsReadOnly();
    // }

    public string AsignarCadeteAPedido(string idCadete, string idPedido)
    {
        Pedido auxPedido = null;// no es necesario instanciar un nuevo objeto
        Cadete auxCadete = null;
        foreach (var pedido in this.pedidos)
        {
            if (pedido.ObtenerID() == idPedido)
            {
                if (pedido.EsPedidoCompleto())
                {
                    return "El pedido ya está completo";
                }
                if (pedido.TieneCadeteAsignado())
                {
                    return "El pedido ya tiene un cadete asignado";
                }
                auxPedido = pedido;
                break;
            }
        }
        foreach (var cadete in this.cadetes)
        {
            if (cadete.ObtenerID() == idCadete)
            {
                auxCadete = cadete;
                break;
            }
        }
        if (auxPedido != null && auxCadete != null)
        {
            auxPedido.AsignarCadete(auxCadete); // asignar el cadete completo
            return "Cadete asignado con éxito";
        }
        else
        {
            if (auxPedido == null)
            {
                return "No se encontro el pedido";
            }
            if (auxCadete == null)
            {
                return "No se encontro el cadete";
            }
        }
        return "Error inesperado";
    }
    public string CambiarEstadoDePedido(string idCadete, string idPedido, Pedido.EstadoPedido nuevoEstado)
    {
        Pedido auxPedido = null;
        Cadete auxCadete = null;
        foreach (var pedido in this.pedidos)
        {
            if (pedido.ObtenerID() == idPedido)
            {
                if (pedido.EsPedidoCompleto())
                {
                    return "El pedido ya está completo";
                }
                auxPedido = pedido;
                break;
            }
        }
        foreach (var cadete in this.cadetes)
        {
            if (cadete.ObtenerID() == idCadete)
            {
                auxCadete = cadete;
                break;
            }
        }
        if (auxPedido != null && auxCadete != null)
        {
            if (auxPedido.ObtenerIdCadeteAsignado() == idCadete && auxPedido.TieneCadeteAsignado())
            {
                if (auxPedido.ObtenerEstado() != Pedido.EstadoPedido.Completado)
                {
                    auxPedido.CambiarEstado(nuevoEstado);
                    if (nuevoEstado == Pedido.EstadoPedido.Completado)
                    {
                        auxCadete.IncrementarPedidosCompletos();
                    }
                    return $"Estado del pedido cambiado a {nuevoEstado}";
                }
                else
                {
                    return "No se puede cambiar el estado de un pedido (ya completo o no asignado)";
                }
            }
            else
            {
                return "No se puede cambiar el estado de un pedido";
            }
        }
        else
        {
            if (auxPedido == null)
            {
                return "No se encontró el pedido";
            }
            if (auxCadete == null)
            {
                return "No se encontró el cadete";
            }
        }
        return "Error inesperado.";
    }

    public string CadeteDePedido(string idPedido)
    {
        foreach (var pedido in this.pedidos)
        {
            if (pedido.ObtenerID() == idPedido)
            {
                return pedido.ObtenerIdCadeteAsignado();
            }
        }
        return null;
    }

    public string ReasignarPedido(string idCadetePrevio, string idCadete, string idPedido)
    {
        Pedido auxPedido = null;
        foreach (var pedido in this.pedidos)
        {
            if (pedido.ObtenerIdCadeteAsignado() == idCadetePrevio)
            {
                if (pedido.EsPedidoCompleto())
                {
                    return "El pedido ya está completo";
                }
                auxPedido = pedido;
                break;
            }
        }
        if (auxPedido != null)
        {
            auxPedido.AsignarCadete(null);
            return AsignarCadeteAPedido(idCadete, idPedido);
        }
        return "Error inesperado";
    }

    public string ListaPedidosAsignados()
    {
        string lista = "";
        foreach (var pedido in this.pedidos)
        {
            if (!pedido.TieneCadeteAsignado())
            {
                lista += pedido.ObtenerDatos() + "\n";
            }
        }
        return lista;
    }

    public string ListadoCadetes(string idCadete)
    {
        string lista = "";
        foreach (var cadete in this.cadetes)
        {
            if (cadete.ObtenerID() != idCadete)
            {
                lista += cadete.ObtenerDatos() + "\n";
            }
        }
        return lista;
    }

    public string ListadoPedidosNoCompletosAsignados()
    {
        string lista = "";
        foreach (var pedido in this.pedidos)
        {
            if (!pedido.EsPedidoCompleto() && pedido.TieneCadeteAsignado())
            {
                lista += pedido.ObtenerDatos() + "\n";
            }
        }
        return lista;
    }


    public string Informe()
    {
        string lista = "";
        foreach (var cadete in this.cadetes)
        {
            int pedidosComp = this.pedidos.Where(p => p.ObtenerIdCadeteAsignado() == cadete.ObtenerID() && p.EsPedidoCompleto()).Count();
            float jornada = pedidosComp * 500; //campo privado en cadeteria de 500
            lista += $"Cadete: {cadete.ObtenerNombre()}\nPedidos Compretados: {pedidosComp}\nMonto a cobrar: ${jornada.ToString()} \n";
        }
        return lista;
    }

    public Pedido ObtenerPedido(string idPedido)
    {
        foreach (var pedido in this.pedidos)
        {
            if (pedido.ObtenerID() == idPedido)
            {
                return pedido;
            }
        }
        return null;
    }


}







