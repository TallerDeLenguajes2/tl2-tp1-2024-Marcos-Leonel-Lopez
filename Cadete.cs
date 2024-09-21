
// public class Cadete : IData, IIdentificador
// {
//     private string id;
//     private string nombre;
//     private string direccion;
//     private string telefono;
//     private int numPedidosCompletos;


//     public Cadete()
//     {
//     }
//     public Cadete(string id, string nombre, string direccion, string telefono)
//     {
//         this.id = id;
//         this.nombre = nombre;
//         this.direccion = direccion;
//         this.telefono = telefono;
//         this.numPedidosCompletos = 0;

//     }

//     public string ObtenerID()
//     {
//         return this.id;
//     }
//     public string ObtenerDatos()
//     {
//         return $"ID: {this.id}, Nombre: {this.nombre}, Número de Pedidos Completos: {this.numPedidosCompletos}";
//     }

//     public void IncrementarPedidosCompletos()
//     {
//         this.numPedidosCompletos++;
//     }

//     public int PedidosCompletos()
//     {
//         return this.numPedidosCompletos;
//     }
//     public string ObtenerNombre()
//     {
//         return this.nombre;
//     }

// }

using System.Text.Json.Serialization;

public class Cadete : IData, IIdentificador
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }

    [JsonPropertyName("direccion")]
    public string Direccion { get; set; }

    [JsonPropertyName("telefono")]
    public string Telefono { get; set; }

    [JsonPropertyName("numPedidosCompletos")]
    public int NumPedidosCompletos { get; set; }

    public Cadete()
    {
    }

    public Cadete(string id, string nombre, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        NumPedidosCompletos = 0;
    }

    public string ObtenerID() => Id;
    public string ObtenerDatos() => $"ID: {Id}, Nombre: {Nombre}, Número de Pedidos Completos: {NumPedidosCompletos}";
    public void IncrementarPedidosCompletos() => NumPedidosCompletos++;
    public int PedidosCompletos() => NumPedidosCompletos;
    public string ObtenerNombre() => Nombre;
}
