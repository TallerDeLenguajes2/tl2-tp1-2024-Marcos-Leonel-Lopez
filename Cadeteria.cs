public class Cadeteria
{
    private string nombre;
    private string telefono;
    public List<Cadete> cadetes;
    public List<Pedido> pedidos;

    private static int cont = 1;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.cadetes = new List<Cadete>();
        this.pedidos = new List<Pedido>();
    }


    public void CargarCadetesDesdeCSV(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines[1..]) // Ignora la primera línea de encabezados
        {
            var values = line.Split(',');
            var cadete = new Cadete(values[0], values[1], values[2], values[3]);
            this.cadetes.Add(cadete);
        }
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

    public string NombreCadeteria()
    {
        return this.nombre;
    }
    public IReadOnlyList<Pedido> ListaPedidos()
    {
        return this.pedidos.AsReadOnly();
    }
    public IReadOnlyList<Cadete> ListaCadetes()
    {
        return this.cadetes.AsReadOnly();
    }

    public string AsignarCadeteAPedido(string idCadete, string idPedido)
    {
        Pedido auxPedido = new Pedido();
        Cadete auxCadete = new Cadete();
        foreach (var pedido in this.pedidos)
        {
            if (pedido.obtenerID() == idPedido)
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
            auxPedido.AsignarCadete(auxCadete.ObtenerID());
            return "Cadete asignado con éxito";
        }
        else
        {
            if (auxPedido != null)
            {
                return "No se encontro el pedido";
            }
            if (auxCadete != null)
            {
                return "No se encontro el cadete";
            }
        }
        return "Error inesperado";
    }
    public string CambiarEstadoDePedido(string idCadete, string idPedido, Pedido.EstadoPedido nuevoEstado)
    {
        Pedido auxPedido = new Pedido();
        Cadete auxCadete = new Cadete();
        foreach (var pedido in this.pedidos)
        {
            if (pedido.obtenerID() == idPedido)
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
            if (auxPedido.ObtenerCadeteAsignado() != idCadete)
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
                    return "No se puede cambiar el estado de un pedido que ya está completo";
                }
            }
            else
            {
                return "El pedido no corresponde al cadete";
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







}







