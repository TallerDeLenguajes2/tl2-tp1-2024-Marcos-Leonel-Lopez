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

    private static int cont = 1;


    public Pedido(){
        
    }
    public Pedido(string obs, string nombre, string direccion, string telefono, string referenciaDireccion)
    {
        this.nro = cont.ToString();
        cont++;
        this.obs = obs;
        this.cliente = new Cliente(nombre, direccion, telefono, referenciaDireccion);
        this.estado = EstadoPedido.Pendiente;
    }

    public string obtenerID(){
        return this.nro;
    }
    public string VerDatosCliente()
    {
        return this.cliente.obtenerNombre();
    }
    public string VerDireccionCliente()
    {
        return this.cliente.obtenerDireccion();
    }

    public string VerDatosPedido(){
        return $"Nro: {this.nro}, Obs: {this.obs}, Cliente: {this.VerDatosCliente()}, Dirección: {this.VerDireccionCliente()}, estaado: {this.estado}";
    }

    public void CambiarEstado(EstadoPedido nuevoEstado)
    {
        this.estado = nuevoEstado;
    }

    public bool EsPedidoCompleto(){
        return this.estado == EstadoPedido.Completado;
    }

    public Cadete PerteneceA(List<Cadete> cadetes){
        foreach(Cadete cadete in cadetes){
            if(cadete.ListaPedidos().Contains(this))
                return cadete;
        }
        return null;
    }

}