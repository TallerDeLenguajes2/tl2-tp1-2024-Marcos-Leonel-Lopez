using System.Text.Json;
public abstract class AccesoADatos
{
    public abstract List<Cadete> CargarCadetes(string filePath);
}
public class AccesoCSV : AccesoADatos
{
    public override List<Cadete> CargarCadetes(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }
        var cadetes = new List<Cadete>();
        var lineas = File.ReadAllLines(filePath);

        foreach (var linea in lineas[1..]) // Ignora la primera línea de encabezados
        {
            var valores = linea.Split(',');
            var cadete = new Cadete(valores[0], valores[1], valores[2], valores[3]);
            cadetes.Add(cadete);
        }

        return cadetes;
    }
}
public class AccesoJSON : AccesoADatos
{
    public override List<Cadete> CargarCadetes(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }
        var jsonString = File.ReadAllText(filePath);
        var cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
        return cadetes ?? new List<Cadete>();  // Devuelve una lista vacía si es null
    }
}
