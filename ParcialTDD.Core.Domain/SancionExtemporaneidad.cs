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
        private DateTime FechaOficialDeclaracion;
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
                if (emplazamiento)
                {
                    return ValorDeclarar * diasExtermporneos * 0.10m;
                }
                else
                {
                    return ValorDeclarar * diasExtermporneos * 0.05m;
                }
            }
            else
            {
                if (emplazamiento)
                {
                    return diasExtermporneos * SMLDV * 2m;
                }
                else
                {
                    return diasExtermporneos * SMLDV;
                }
            }
            throw new NotImplementedException();
        }
        private int CalcularDiasExtemporaneos(DateTime fechaDeclaracion)
        {

            TimeSpan dias = fechaDeclaracion - FechaOficialDeclaracion;
            var ndias = dias.Days;
            if (ndias <= 0)
            {
                return 0;
            }
            else
            {
                return ndias;
            }
        }
    }
}
