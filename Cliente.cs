public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string referenciaDireccion;
    public Cliente(string nombre, string direccion, string telefono, string referenciaDireccion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.referenciaDireccion = referenciaDireccion;
    }
    public string obtenerDireccion(){
        return this.direccion;
    }
    public string obtenerNombre(){
        return this.nombre;
    }

}