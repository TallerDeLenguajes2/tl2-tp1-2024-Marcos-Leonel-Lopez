using System.Net.WebSockets;
using System.Xml;
Random random = new Random();
List<Pedido> pedidos = new List<Pedido>();
Pedido auxPedido = new Pedido();
Cadete auxCadete = new Cadete();
var cadeteria1 = new Cadeteria("Rappi", "32111321");
var cadeteria2 = new Cadeteria("Globo", "12344123");
// cadeteria1.CargarCadetesDesdeCSV("./assets/Cadeteria1.csv");
// cadeteria2.CargarCadetesDesdeCSV("./assets/Cadeteria2.csv");
cadeteria1.CargarCadete("Marcos", "123123", "321321");
cadeteria1.CargarCadete("Luis", "234234", "432432");
cadeteria1.CargarCadete("Roberto", "345345", "543543");
cadeteria2.CargarCadete("Ana", "678678", "876876");
cadeteria2.CargarCadete("Nina", "146146", "641641");

pedidos.Add(new Pedido("observacion ---", "naty", "Lamadrid", "tel ---", "referencia ---"));
pedidos.Add(new Pedido("observacion ---", "pau", "gral paz", "tel ---", "referencia ---"));
pedidos.Add(new Pedido("observacion ---", "pao", "9 julio", "tel ---", "referencia ---"));




int opc;
while (true)
{
    Renderizar.MostrarMenu(Constantes.Menu);
    if (!int.TryParse(Console.ReadLine(), out opc))
    {
        System.Console.WriteLine("Entrada invalida. Por favor, ingrese un numero.");
        continue;
    }
    if (opc >= 1 && opc <= 6)
    {
        switch (opc)
        {
            case 1: //alta
                System.Console.WriteLine("Nombre Cliente:");
                string nombre = Console.ReadLine();
                System.Console.WriteLine("Direccion Cliente");
                string direccion = Console.ReadLine();
                // pedidos.Add(new Pedido("observacion ---", nombre, direccion, "tel ---", "referencia ---"));
                System.Console.WriteLine("Pedido creado");
                break;
            case 2: //asignar
                auxPedido = null;
                System.Console.WriteLine("Lista de pedidos:");
                foreach (var pedido in pedidos)
                {
                    System.Console.WriteLine($"{pedido.VerDatosPedido()}");
                }
                System.Console.WriteLine("=============");
                System.Console.WriteLine($"Lista de cadetes: {cadeteria1.nombreCadeteria()}");
                foreach (var cadete in cadeteria1.Cadetes)
                {
                    System.Console.WriteLine($"{cadete.DatosCadete()}");

                }
                System.Console.WriteLine("=============");
                System.Console.WriteLine($"Lista de cadetes: {cadeteria2.nombreCadeteria()}");
                foreach (var cadete in cadeteria2.Cadetes)
                {
                    System.Console.WriteLine($"{cadete.DatosCadete()}");
                }

                System.Console.WriteLine("Indicar nro. de pedido a asignar:");
                string nPedido = Console.ReadLine();
                System.Console.WriteLine("Indicar nro. de cadete a asignar:");
                string nCadete = Console.ReadLine();

                foreach (var pedido in pedidos)
                {
                    if (pedido.obtenerID() == nPedido)
                    {
                        auxPedido = pedido;
                        break;
                    }
                }

                foreach (var cadete in cadeteria1.Cadetes)
                {
                    if (cadete.obtenerID() == nCadete)
                    {
                        auxCadete = cadete;
                        break;
                    }
                }
                if (auxCadete == null)
                {
                    foreach (var cadete in cadeteria2.Cadetes)
                    {
                        if (cadete.obtenerID() == nCadete)
                        {
                            auxCadete = cadete;
                            break;
                        }
                    }
                }



                if (auxPedido != null && auxCadete != null)
                {
                    auxCadete.asignarPedido(auxPedido);
                    pedidos.Remove(auxPedido);
                }


                break;
            case 3: //cambiar estado

                break;
            case 4: //reasignar pedido

                break;
            case 5: //mostrar informe

                break;
            case 6:
                // Console.Clear();
                System.Console.WriteLine("Pedido:");
                foreach (var pedido in pedidos)
                {
                    System.Console.WriteLine("==========");
                    System.Console.WriteLine($"{pedido.VerDatosPedido()}");
                    System.Console.WriteLine("==========");
                }
                Thread.Sleep(2500);
                // Console.Clear();
                System.Console.WriteLine("Cadeteria: ");
                foreach (var cadete in cadeteria1.Cadetes)
                {
                    System.Console.WriteLine($"{cadete.DatosCadete()}");

                }
                System.Console.WriteLine("=============");
                foreach (var cadete in cadeteria2.Cadetes)
                {
                    System.Console.WriteLine($"{cadete.DatosCadete()}");
                }
                Thread.Sleep(2500);

                break;
        }
    }
    else
    {
        System.Console.WriteLine("Finalizando programa...");
        return;
    }
}