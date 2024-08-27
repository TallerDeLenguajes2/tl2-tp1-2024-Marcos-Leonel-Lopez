public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes = new List<Cadete>();


    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
    }

    public List<Cadete> Cadetes { get => cadetes;}

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
}







