public class Cadete
{
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;
    private int numPedidosCompletos;
    private List<Pedido> Pedidos = new List<Pedido>();
    
    public Cadete(string id,string nombre,string direccion,string telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.numPedidosCompletos = 0;
    }

    public string DatosCadete(){
        return $"ID: {this.id}, Nombre: {this.nombre}, Dirección: {this.direccion}, Teléfono: {this.telefono}, Número de Pedidos: {this.numPedidosCompletos}";
    }

// Si no agregas IReadOnlyList, el código externo puede modificar la lista directamente

// Cadete cadete = new Cadete();
// List<Pedido> pedidosExternos = cadete.ListaPedidos();
//  Modificar la lista directamente
// pedidosExternos.Add(new Pedido { /* propiedades del pedido */ });
// pedidosExternos.RemoveAt(0);  Eliminar el primer pedido
// pedidosExternos.Clear();  Eliminar todos los pedidos
    public IReadOnlyList<Pedido> ListaPedidos()
    {
        return Pedidos.AsReadOnly();
    }

}