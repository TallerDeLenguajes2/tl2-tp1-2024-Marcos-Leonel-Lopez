public class Pedido : IData
{
    public enum EstadoPedido
    {
        Pendiente,
        Completado,
        Fallido
    }
    private string idPedido;
    private string obs;
    private Cliente cliente;
    private EstadoPedido estado;
    private string refCadete;
    private static int cont = 1;


    public Pedido()
    {
    }
    public Pedido(string obs, string nombre, string direccion, string telefono, string referenciaDireccion)
    {
        this.idPedido = cont.ToString();
        cont++;
        this.obs = obs;
        this.cliente = new Cliente(nombre, direccion, telefono, referenciaDireccion);
        this.estado = EstadoPedido.Pendiente;
        this.refCadete = null;
    }

    public string ObtenerID()
    {
        return this.idPedido;
    }
    public string ObtenerDatos()
    {
        string refCadete = null != this.refCadete ? this.refCadete : "Sin cadete asignado";
        return $"Id pedido: {this.idPedido}, Obs: {this.obs}, Cliente: {this.VerDatosCliente()}, Dirección: {this.VerDireccionCliente()}, Estado: {this.estado}, Ref. cadete asignado: {refCadete}";
    }
    public string VerDatosCliente()
    {
        return this.cliente.obtenerNombre();
    }
    public string VerDireccionCliente()
    {
        return this.cliente.obtenerDireccion();
    }
    public string ObtenerCadeteAsignado()
    {
        return this.refCadete;
    }
    public EstadoPedido ObtenerEstado()
    {
        return this.estado;
    }
    public void CambiarEstado(EstadoPedido nuevoEstado)
    {
        this.estado = nuevoEstado;
    }
    public void AsignarCadete(string idCadete)
    {
        this.refCadete = idCadete;
    }
    public bool EsPedidoCompleto()
    {
        return this.estado == EstadoPedido.Completado;
    }
    public bool TieneCadeteAsignado()
    {
        return this.refCadete != null;
    }
    // public Cadete PerteneceA(List<Cadete> cadetes){
    //     foreach(Cadete cadete in cadetes){
    //         if(cadete.ListaPedidos().Contains(this))
    //             return cadete;
    //     }
    //     return null;
    // }

}