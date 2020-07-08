using ClasesStock;
using System;


namespace ConsoleModelos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancio modelo
            ModeloClasicoDeCantidadEconomicaDePedido MCCEP = new ModeloClasicoDeCantidadEconomicaDePedido();
            
            //Cargo Datos
            Console.WriteLine("Ingrese Demanda Diaria:");
            MCCEP.TasaDeDemanda= Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese Costo del Pedido:");
            MCCEP.CostoDePreparacionPedido = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese Costo del almacenamiento:");
            MCCEP.CostoAlmacenamiento = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese Tiempo de Entrega del Pedido :");
            MCCEP.TiempoDeEntregaPositivo = Convert.ToDouble(Console.ReadLine());
            
            //Calculo para obtener la politica
            MCCEP.CantidadEconocmicaDelPedido= MCCEP.CalcularCantidadEconomicaDelPedido();

            MCCEP.PuntoDeReorden= MCCEP.CalcularPuntoDeReorden();

            //Muestro Politica
            Console.WriteLine(MCCEP.ObtenerPoliticaInventario());

            //Calculo costo inventario
            MCCEP.CostoTotalPorUnidadDeTimepo= MCCEP.CalcularCostoDiarioInventario();
            //Muestro costo inventario con dicha politica
            Console.WriteLine(MCCEP.ObtenerCostoDeInventarioPorPolitica());
            Console.ReadLine();


        }
    }
}
