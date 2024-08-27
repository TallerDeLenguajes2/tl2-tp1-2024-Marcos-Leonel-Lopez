using System.Net.WebSockets;
List<string> Menu = new List<string>{
    "Dar Alta",
    "Asiganar pedido",
    "Cambiar estado",
    "Reasignar pedido",
    "Mostrar informe"
 };
// var cadeteria1 = new Cadeteria("PedidosYa","32111321");
// var cadeteria2 = new Cadeteria("Globo","12344123");
// cadeteria1.CargarCadetesDesdeCSV("./assets/Cadeteria1.csv");
// cadeteria2.CargarCadetesDesdeCSV("./assets/Cadeteria2.csv");

// foreach(var cadete in cadeteria1.Cadetes){
//     System.Console.WriteLine(cadete.DatosCadete());
// }
// foreach(var cadete in cadeteria2.Cadetes){
//     System.Console.WriteLine(cadete.DatosCadete());
// }
int opc;
while (true)
{
    Interface.MostrarMenu(Menu);
    if (!int.TryParse(Console.ReadLine(), out opc))
    {
        System.Console.WriteLine("Entrada invalida. Por favor, ingrese un numero.");
        continue;
    }
    if (opc >= 1 && opc <= 5)
    {
        System.Console.WriteLine($"ingreso {opc}");
        Thread.Sleep(1000);
        // switch (opc)
        // {
        //     case 1: //alta

        //         break;
        //     case 2: //asignar

        //         break;
        //     case 3: //cambiar estado

        //         break;
        //     case 4: //reasignar pedido

        //         break;
        //     case 5: //mostrar informe

        //         break;
        // }
    }else{
        System.Console.WriteLine("Finalizando programa...");
        return;
    }
}