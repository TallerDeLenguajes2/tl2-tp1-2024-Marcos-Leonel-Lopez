public class Pedido
{
    public enum EstadoPedido
    {
        Pendiente,
        Completado,
        Fallido
    }
    private string nro;
    private string obs;
    private Cliente cliente;
    private EstadoPedido estado;
    private void GenerarNumeroPedido()
    {
        Random random = new Random();
        int numeroAleatorio = random.Next(1000, 9999);  // Genera un número aleatorio entre 1000 y 9999
        this.nro = numeroAleatorio.ToString();  // Asigna el número aleatorio a 'nro'
    }
    public Pedido(string obs, string nombre, string direccion, string telefono, string referenciaDireccion)
    {
        GenerarNumeroPedido();
        this.obs = obs;
        this.cliente = new Cliente(nombre, direccion, telefono, referenciaDireccion);
        this.estado = EstadoPedido.Pendiente;
    }

    public Cliente VerDatosCliente()
    {
        return this.cliente;
    }
    public string VerDireccionCliente()
    {
        return this.cliente.obtenerDireccion();
    }


}