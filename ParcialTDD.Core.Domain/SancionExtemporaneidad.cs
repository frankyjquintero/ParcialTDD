using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialTDD.Core.Domain
{
    public class SancionExtemporaneidad : ISanciones
    {
        private readonly decimal SMLDV ;
        private readonly DateTime FechaOficialDeclaracion;
        public SancionExtemporaneidad(decimal sMLDV, DateTime fechaOficialDeclaracion)
        {
            FechaOficialDeclaracion = fechaOficialDeclaracion;
            SMLDV  = sMLDV ;
        }
        
        public decimal Liquidar(decimal ValorDeclarar, DateTime fechaDeclaracion, bool emplazamiento = false)
        {
            var diasExtermporneos = CalcularDiasExtemporaneos(fechaDeclaracion);
            if (ValorDeclarar > 0)
            {
                var liquidacionParcial = ValorDeclarar * diasExtermporneos;
                return emplazamiento ? (liquidacionParcial * 0.10m) : (liquidacionParcial * 0.05m);
            }
            else
            {
                var liquidacionParcialCero = diasExtermporneos * SMLDV;
                return emplazamiento ? (liquidacionParcialCero * 2) : liquidacionParcialCero;
            }
        }
        private int CalcularDiasExtemporaneos(DateTime fechaDeclaracion)
        {
            TimeSpan dias = fechaDeclaracion - FechaOficialDeclaracion;
            var ndias = dias.Days;
            return (ndias >= 0) ? ndias : 0;
        }
    }
}
