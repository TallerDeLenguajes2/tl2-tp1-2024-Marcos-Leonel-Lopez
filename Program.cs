using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Xml;
Random random = new Random();
Pedido auxPedido = new Pedido();
Cadete auxCadete = new Cadete();
List<Cadete> listaCadetesAux = new List<Cadete>();
string nCadete;
string nPedido;
string res;

var cadeteria = new Cadeteria("Rappi", "32111321");

// cadeteria.CargarCadete("Marcos", "123123", "321321");
// cadeteria.CargarCadete("Luis", "234234", "432432");
// cadeteria.CargarCadete("Roberto", "345345", "543543");
// cadeteria.CargarCadete("Ana", "678678", "876876");
// cadeteria.CargarCadete("Nina", "146146", "641641");

int opc;
System.Console.WriteLine("Forma cargar datos:");
Renderizar.MostrarMenu(Constantes.FuenteDatos);
while (true)
{
    if (int.TryParse(Console.ReadLine(), out opc))
    {
        if (opc >= 1 && opc <= 2)
        {

            switch (opc)
            {
                case 1:
                    var accesoCSV = new AccesoCSV();
                     listaCadetesAux = accesoCSV.CargarCadetes("../../../assets/cadetes.csv"); // debug
                    //listaCadetesAux = accesoCSV.CargarCadetes("assets/cadetes.csv");
                    break;
                case 2:
                    var accesoJSON = new AccesoJSON();
                     listaCadetesAux = accesoJSON.CargarCadetes("../../../assets/cadetes.json"); // debug
                    //listaCadetesAux = accesoJSON.CargarCadetes("assets/cadetes.json");
                    break;
            }
            if (listaCadetesAux != null)
            {
                cadeteria.CargarListadoCadetes(listaCadetesAux);
            }
            else
            {
                System.Console.WriteLine("No se pudo cargar el archivo.");
            }
        }
        break;
    }
    System.Console.WriteLine("Entrada invalida. Por favor, ingrese un numero.");

}





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
                    // System.Console.WriteLine("Nombre Cliente:");
                    // string nombre = Console.ReadLine();
                    // System.Console.WriteLine("Direccion Cliente");
                    // string direccion = Console.ReadLine();
                    // System.Console.WriteLine("Telefono Cliente:");
                    // string telefono = Console.ReadLine();
                    // System.Console.WriteLine("Referencia Direccion Cliente:");
                    // string referenciaDireccion = Console.ReadLine();
                    // System.Console.WriteLine("Observacion:");
                    // string observacion = Console.ReadLine();
                    // cadeteria.CargarPedido(observacion, nombre, direccion, telefono,referenciaDireccion);


                // cadeteria.CargarPedido("observacion ---", nombre, direccion, telefono, referenciaDireccion);
                cadeteria.CargarPedido("observacion ---", "Juan", "Lamadrid", "tel ---", "referencia ---");
                cadeteria.CargarPedido("observacion ---", "Juan", "Lamadrid", "tel ---", "referencia ---");
                cadeteria.CargarPedido("observacion ---", "Pau", "gral paz", "tel ---", "referencia ---");
                cadeteria.CargarPedido("observacion ---", "Pao", "9 julio", "tel ---", "referencia ---");
                System.Console.WriteLine("Pedido creado");
                break;
            case 2: //asignar
                auxPedido = null;
                auxCadete = null;
                System.Console.WriteLine("Lista de pedidos:");
                System.Console.WriteLine(cadeteria.ListaPedidosAsignados());
                System.Console.WriteLine("=============");
                System.Console.WriteLine($"Lista de cadetes: {cadeteria.ObtenerDatos()}");
                System.Console.WriteLine(cadeteria.ListadoCadetes(null));
                System.Console.WriteLine("=============");
                System.Console.WriteLine("Indicar nro. de pedido a asignar:");
                nPedido = Console.ReadLine();
                System.Console.WriteLine("Indicar nro. de cadete a asignar:");
                nCadete = Console.ReadLine();
                res = cadeteria.AsignarCadeteAPedido(nCadete, nPedido);
                System.Console.WriteLine(res);
                break;
            case 3: //cambiar estado hacerlo de forma ciclica o indicar primeramente que se hara..7
                auxPedido = null;
                System.Console.WriteLine("Lista de pedidos:");
                System.Console.WriteLine(cadeteria.ListadoPedidosNoCompletosAsignados());
                System.Console.WriteLine("Indicar nro. de pedido para cambiar su estado:");
                nPedido = Console.ReadLine();
                System.Console.WriteLine("Ingrese nuevo estado (0: Pendiente, 1: Completo, 2: Fallido):");
                string nuevoEstado = Console.ReadLine();
                auxPedido = cadeteria.ObtenerPedido(nPedido);
                if (auxPedido == null)
                {
                    System.Console.WriteLine("Pedido no encontrado");
                    break;
                }
                // 'hardcodeo el id del cadete, pensando que ese dato lo podria obtener de la request'
                if (nuevoEstado == "0")
                {
                    res = cadeteria.CambiarEstadoDePedido(auxPedido.ObtenerIdCadeteAsignado(), nPedido, Pedido.EstadoPedido.Pendiente);
                }
                else if (nuevoEstado == "1")
                {
                    res = cadeteria.CambiarEstadoDePedido(auxPedido.ObtenerIdCadeteAsignado(), nPedido, Pedido.EstadoPedido.Completado);

                }
                else if (nuevoEstado == "2")
                {
                    res = cadeteria.CambiarEstadoDePedido(auxPedido.ObtenerIdCadeteAsignado(), nPedido, Pedido.EstadoPedido.Fallido);
                }
                else
                {
                    res = "Opcion invalida";
                }
                System.Console.WriteLine(res);
                break;
            case 4: //reasignar pedido
                auxPedido = null;
                auxCadete = null;
                string idCadetePrevio = null;
                System.Console.WriteLine("Lista de pedidos:");
                System.Console.WriteLine(cadeteria.ListadoPedidosNoCompletosAsignados());
                System.Console.WriteLine("Indicar nro. de pedido a reasignar:");
                nPedido = Console.ReadLine();
                idCadetePrevio = cadeteria.CadeteDePedido(nPedido);
                if (idCadetePrevio == null)
                {
                    System.Console.WriteLine("ERROR");
                    break;
                }
                System.Console.WriteLine("Cadete a asignar:");
                System.Console.WriteLine(cadeteria.ListadoCadetes(idCadetePrevio));
                System.Console.WriteLine("Indicar nro. de cadete a asignar:");
                nCadete = Console.ReadLine();
                if (nCadete == idCadetePrevio)
                {
                    System.Console.WriteLine("ERROR");
                    break;
                }
                res = cadeteria.ReasignarPedido(idCadetePrevio, nCadete, nPedido);
                System.Console.WriteLine(res);
                break;
            case 5: //mostrar informe
                System.Console.WriteLine("=============");
                System.Console.WriteLine($"Informe de cadetes en: {cadeteria.ObtenerDatos()}");
                System.Console.WriteLine(cadeteria.Informe());

                break;
            case 6:
                // Console.Clear();
                System.Console.WriteLine("Cadetes:");
                System.Console.WriteLine(cadeteria.ListadoCadetes(null));
                // foreach (var pedido in pedidos)
                // {
                //     System.Console.WriteLine("==========");
                //     System.Console.WriteLine($"{pedido.VerDatosPedido()}");
                //     System.Console.WriteLine("==========");
                // }
                // Thread.Sleep(2500);
                // // Console.Clear();
                // System.Console.WriteLine("Cadeteria: ");
                // foreach (var cadete in cadeteria.Cadetes)
                // {
                //     System.Console.WriteLine($"{cadete.DatosCadete()}");

                // }
                // System.Console.WriteLine("=============");
                // Thread.Sleep(2500);
                break;
        }
    }
    else
    {
        System.Console.WriteLine("Finalizando programa...");
        return;
    }
}