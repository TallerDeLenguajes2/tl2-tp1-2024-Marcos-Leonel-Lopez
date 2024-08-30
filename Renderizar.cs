public static class Renderizar
{
    public static void MostrarMenu<T>(List<T> elementos)
    {
        Console.Clear();
        System.Console.WriteLine("===== MENU =====");
        System.Console.WriteLine();
        for (int i = 0; i < elementos.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}- {elementos[i]}");
        }
        System.Console.WriteLine("Cualquier otro numero para salir.");
        System.Console.WriteLine();
        System.Console.WriteLine("Ingrese una opcion:");
    }
}
