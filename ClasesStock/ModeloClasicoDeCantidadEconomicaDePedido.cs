using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesStock
{
    public class ModeloClasicoDeCantidadEconomicaDePedido
    {
        //public double CantidadPedida { get; set; } = 0;
        public double TasaDeDemanda { get; set; } = 0;
        public double DuracionDeCicloDePedido { get; set; } = 0;
        public double PromedioInventario { get; set; } = 0;
        public double CostoDePreparacionPedido { get; set; } = 0;
        public double CostoAlmacenamiento { get; set; } = 0;
        public double CostoTotalPorUnidadDeTimepo { get; set; } = 0;
        public double CantidadEconocmicaDelPedido { get; set; } = 0;
        public double TiempoDeEntregaPositivo { get; set; } = 0;
        public double TiempoEfectivoDeEntrega { get; set; } = 0;
        public int NumeroEntero { get; set; } = 0;
        public double PuntoDeReorden { get; set; } = 0;


        public string ObtenerPoliticaInventario()
        {
            string politica;
            if(NumeroEntero==0)
            {
                politica = $"Pedir {CantidadEconocmicaDelPedido} unidades cada {DuracionDeCicloDePedido} unidades de tiempo";
            }
            else
            {
                politica = $"Pedir la cantidad {CantidadEconocmicaDelPedido} siempre que la cantidad de inventario baje de {PuntoDeReorden} unidades" ;
            }
            return (politica);
        }

        public string ObtenerCostoDeInventarioPorPolitica()
        {
            return ($"El costo diario de inventario correspondiente a la politica propuesta es {CostoTotalPorUnidadDeTimepo}");
        }

        public double CalcularCantidadEconomicaDelPedido()
        {
            CantidadEconocmicaDelPedido = Math.Sqrt((2 * CostoDePreparacionPedido * TasaDeDemanda) / CostoAlmacenamiento);
            return CantidadEconocmicaDelPedido;
        }

        public double CalcularPuntoDeReorden()
        {
            
            DuracionDeCicloDePedido = CantidadEconocmicaDelPedido / TasaDeDemanda;
            if (TiempoDeEntregaPositivo > DuracionDeCicloDePedido)
            {
                NumeroEntero = Convert.ToInt32(Math.Truncate(TiempoDeEntregaPositivo / DuracionDeCicloDePedido));
                TiempoEfectivoDeEntrega = TiempoDeEntregaPositivo - NumeroEntero * DuracionDeCicloDePedido;
                PuntoDeReorden = TiempoEfectivoDeEntrega * TasaDeDemanda;
            }
            return PuntoDeReorden;
        }

        public double CalcularCostoDiarioInventario()
        {
            PromedioInventario = CantidadEconocmicaDelPedido / 2;
            CostoTotalPorUnidadDeTimepo = CostoDePreparacionPedido / (CantidadEconocmicaDelPedido / TasaDeDemanda) + CostoAlmacenamiento * (PromedioInventario);
            return CostoTotalPorUnidadDeTimepo;
        }

        
    }
}

