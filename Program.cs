using System.Net.WebSockets;
Random random = new Random();
List<Pedido> pedidos = new List<Pedido>();
var cadeteria1 = new Cadeteria("PedidosYa","32111321");
var cadeteria2 = new Cadeteria("Globo","12344123");
cadeteria1.CargarCadetesDesdeCSV("./assets/Cadeteria1.csv");
cadeteria2.CargarCadetesDesdeCSV("./assets/Cadeteria2.csv");
// foreach(var cadete in cadeteria1.Cadetes){
//     System.Console.WriteLine(cadete.DatosCadete());
// }
// foreach(var cadete in cadeteria2.Cadetes){
//     System.Console.WriteLine(cadete.DatosCadete());
// }
int opc;
while (true)
{
    Renderizar.MostrarMenu(Constantes.Menu);
    if (!int.TryParse(Console.ReadLine(), out opc))
    {
        System.Console.WriteLine("Entrada invalida. Por favor, ingrese un numero.");
        continue;
    }
    if (opc >= 1 && opc <= 5)
    {
        switch (opc)
        {
            case 1: //alta
                System.Console.WriteLine("Nombre Cliente:");
                string nombre = Console.ReadLine();
                System.Console.WriteLine("Direccion Cliente");
                string direccion = Console.ReadLine();
                System.Console.WriteLine("Telefono Cliente");
                string telefono = Console.ReadLine();
                System.Console.WriteLine("Referencia direccion Cliente");
                string referencia = Console.ReadLine();
                System.Console.WriteLine("Observacion de Cliente");
                string observacion = Console.ReadLine();
                pedidos.Add(new Pedido(observacion,nombre,direccion,telefono,referencia));
                break;
            case 2: //asignar

                break;
            case 3: //cambiar estado

                break;
            case 4: //reasignar pedido

                break;
            case 5: //mostrar informe

                break;
        }
    }else{
        System.Console.WriteLine("Finalizando programa...");
        return;
    }
}