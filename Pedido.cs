public class Pedido
{
    private string nro;
    private string obs;
    private Cliente cliente;
    private string estado;
    public Pedido(string nombre, string direccion, string telefono, string referenciaDireccion)
    {
        this.cliente = new Cliente(nombre, direccion, telefono, referenciaDireccion);
    }

    public Cliente VerDatosCliente(){
        return this.cliente;
    }
    public string VerDireccionCliente(){
        return this.cliente.obtenerDireccion();
    }


}