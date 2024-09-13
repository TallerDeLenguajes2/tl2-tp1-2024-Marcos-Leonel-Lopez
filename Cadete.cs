public class Cadete : IData, IIdentificador
{
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;
    private int numPedidosCompletos;


    public Cadete()
    {
    }
    public Cadete(string id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.numPedidosCompletos = 0;

    }

    public string ObtenerID()
    {
        return this.id;
    }
    public string ObtenerDatos()
    {
        return $"ID: {this.id}, Nombre: {this.nombre}, Número de Pedidos Completos: {this.numPedidosCompletos}";
    }

    public void IncrementarPedidosCompletos()
    {
        this.numPedidosCompletos++;
    }

    public int PedidosCompletos()
    {
        return this.numPedidosCompletos;
    }
    public string ObtenerNombre(){
        return this.nombre;
    }


    // Si no agregas IReadOnlyList, el código externo puede modificar la lista directamente

    // Cadete cadete = new Cadete();
    // List<Pedido> pedidosExternos = cadete.ListaPedidos();
    //  Modificar la lista directamente
    // pedidosExternos.Add(new Pedido { /* propiedades del pedido */ });
    // pedidosExternos.RemoveAt(0);  Eliminar el primer pedido
    // pedidosExternos.Clear();  Eliminar todos los pedidos


}