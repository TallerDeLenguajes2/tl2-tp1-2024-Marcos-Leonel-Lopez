public class Cadeteria
{
    private string nombre;
    private string telefono;
    public List<Cadete> Cadetes { get; } = new List<Cadete>();

    private static int cont = 1;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
    }


    public void CargarCadetesDesdeCSV(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines[1..]) // Ignora la primera línea de encabezados
        {
            var values = line.Split(',');
            var cadete = new Cadete(values[0],values[1],values[2],values[3]);
            Cadetes.Add(cadete);
        }
    }

    public void CargarCadete(string nombre,string cedula,string telefono){
        Cadetes.Add(new Cadete(cont.ToString(), nombre, cedula, telefono));
        cont++;
    }

    public string NombreCadeteria(){
        return this.nombre;
    }
}







