using System.Net.WebSockets;
using System.Xml;
Random random = new Random();
List<Pedido> pedidos = new List<Pedido>();
Pedido auxPedido = new Pedido();
Cadete auxCadete = new Cadete();
string nCadete;
string nPedido;

var cadeteria = new Cadeteria("Rappi", "32111321");

cadeteria.CargarCadete("Marcos", "123123", "321321");
cadeteria.CargarCadete("Luis", "234234", "432432");
cadeteria.CargarCadete("Roberto", "345345", "543543");
cadeteria.CargarCadete("Ana", "678678", "876876");
cadeteria.CargarCadete("Nina", "146146", "641641");

pedidos.Add(new Pedido("observacion ---", "Juan", "Lamadrid", "tel ---", "referencia ---"));
pedidos.Add(new Pedido("observacion ---", "Pau", "gral paz", "tel ---", "referencia ---"));
pedidos.Add(new Pedido("observacion ---", "Pao", "9 julio", "tel ---", "referencia ---"));




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
                auxCadete = null;
                System.Console.WriteLine("Lista de pedidos:");
                foreach (var pedido in pedidos)
                {
                    System.Console.WriteLine($"{pedido.VerDatosPedido()}");
                }
                System.Console.WriteLine("=============");
                System.Console.WriteLine($"Lista de cadetes: {cadeteria.NombreCadeteria()}");
                foreach (var cadete in cadeteria.Cadetes)
                {
                    cadete.verifiarPedidosCompletos();
                    System.Console.WriteLine($"{cadete.DatosCadete()}");

                }
                System.Console.WriteLine("=============");

                System.Console.WriteLine("Indicar nro. de pedido a asignar:");
                nPedido = Console.ReadLine();
                System.Console.WriteLine("Indicar nro. de cadete a asignar:");
                nCadete = Console.ReadLine();

                foreach (var pedido in pedidos)
                {
                    if (pedido.obtenerID() == nPedido)
                    {
                        auxPedido = pedido;
                        break;
                    }
                }

                foreach (var cadete in cadeteria.Cadetes)
                {
                    if (cadete.ObtenerID() == nCadete)
                    {
                        auxCadete = cadete;
                        break;
                    }
                }

                if (auxPedido != null && auxCadete != null)
                {
                    auxCadete.AsignarPedido(auxPedido);
                    pedidos.Remove(auxPedido);
                }
                else
                {
                    if (auxPedido != null)
                    {
                        System.Console.WriteLine("No se encontro el pedido");
                    }
                    if (auxCadete != null)
                    {
                        System.Console.WriteLine("No se encontro el cadete");
                    }
                }
                break;
            case 3: //cambiar estado
                auxPedido = null;
                System.Console.WriteLine("Lista de pedidos:");
                foreach (var cadete in cadeteria.Cadetes)
                {
                    if (cadete.TienePedidos())
                    {
                        cadete.verifiarPedidosCompletos();
                        System.Console.WriteLine(cadete.DatosCadete());
                        foreach (var pedido in cadete.ListaPedidos())
                        {
                            System.Console.WriteLine(pedido.VerDatosPedido());
                        }
                    }
                }
                System.Console.WriteLine("Indicar nro. de pedido para cambiar su estado:");
                nPedido = Console.ReadLine();
                foreach (var cadete in cadeteria.Cadetes)
                {
                    if (cadete.TienePedidos())
                    {
                        // System.Console.WriteLine(cadete.DatosCadete());
                        foreach (var pedido in cadete.ListaPedidos())
                        {
                            if (pedido.obtenerID() == nPedido)
                            {
                                auxPedido = pedido;
                                break;
                            }
                        }
                    }
                }

                if (auxPedido == null)
                {
                    System.Console.WriteLine($"{nPedido} no encontrado");
                    break;
                }
                if (auxPedido.EsPedidoCompleto())
                {
                    System.Console.WriteLine("El pedido ya fue completado");
                    break;
                }
                System.Console.WriteLine(auxPedido.VerDatosPedido());
                System.Console.WriteLine("Ingrese nuevo estado (0: Pendiente, 1: Completo, 2: Fallido):");
                string nuevoEstado = Console.ReadLine();
                if (nuevoEstado == "0")
                {
                    auxPedido.CambiarEstado(Pedido.EstadoPedido.Pendiente);
                }
                else if (nuevoEstado == "1")
                {
                    auxPedido.CambiarEstado(Pedido.EstadoPedido.Completado);
                }
                else if (nuevoEstado == "2")
                {
                    auxPedido.CambiarEstado(Pedido.EstadoPedido.Fallido);
                }
                else
                {
                    System.Console.WriteLine("Opcion invalida");
                }

                break;
            case 4: //reasignar pedido
                    //muestor todos los pedidos y selecciono el que quiero
                auxPedido = null;
                auxCadete = null;
                System.Console.WriteLine("Lista de pedidos:");
                foreach (var cadete in cadeteria.Cadetes)
                {
                    if (cadete.TienePedidos())
                    {
                        cadete.verifiarPedidosCompletos();
                        System.Console.WriteLine(cadete.DatosCadete());
                        foreach (var pedido in cadete.ListaPedidos())
                        {
                            System.Console.WriteLine(pedido.VerDatosPedido());
                        }
                    }
                }
                System.Console.WriteLine("Indicar nro. de pedido para cambiar su estado:");
                nPedido = Console.ReadLine();
                foreach (var cadete in cadeteria.Cadetes)
                {
                    if (cadete.TienePedidos())
                    {
                        foreach (var pedido in cadete.ListaPedidos())
                        {
                            if (pedido.obtenerID() == nPedido)
                            {
                                auxPedido = pedido;
                                break;
                            }
                        }
                    }
                }

                if (auxPedido == null)
                {
                    System.Console.WriteLine($"{nPedido} no encontrado");
                    break;
                }
                if (auxPedido.EsPedidoCompleto())
                {
                    System.Console.WriteLine("El pedido ya fue completado");
                    break;
                }

                auxCadete = auxPedido.PerteneceA(cadeteria.Cadetes);

                auxCadete.QuitarPedido(auxPedido);

                System.Console.WriteLine($"Lista de cadetes: {cadeteria.NombreCadeteria()}");
                foreach (var cadete in cadeteria.Cadetes)
                {
                    cadete.verifiarPedidosCompletos();
                    System.Console.WriteLine($"{cadete.DatosCadete()}");

                }
                System.Console.WriteLine("Seleccionar nuevo cadete:");
                nCadete = Console.ReadLine();
                foreach (var cadete in cadeteria.Cadetes)
                {
                    if (cadete.ObtenerID() == nCadete)
                    {
                        auxCadete = cadete;
                        break;
                    }
                }

                if (auxPedido != null && auxCadete != null)
                {
                    auxCadete.AsignarPedido(auxPedido);
                }

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
                foreach (var cadete in cadeteria.Cadetes)
                {
                    System.Console.WriteLine($"{cadete.DatosCadete()}");

                }
                System.Console.WriteLine("=============");
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