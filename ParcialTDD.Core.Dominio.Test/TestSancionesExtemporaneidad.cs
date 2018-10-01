using NUnit.Framework;
using ParcialTDD.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialTDD.Core.Dominio.Test
{
    [TestFixture]
    public class TestSancionesExtemporaneidad
    {
          /// <summary>
        /// 
        ///Dado que el Valor a Declarar es mayor a Cero y sin emplazamiento
        ///Cuando Liquide la sanción del monto de 100.000 mil pesos el dia 7-octubre-2018(2 dias)
        ///Entonces la Sanción por extemporaneidad es igual a 10000 pesos
        /// </summary>
        [Test]
        public void SancionExtemporaneidadMayorACeroSinEmplazamiento()
        {
            //Arrange(Preparar)
            decimal SMLDV = 781242m / 30m;
            SancionExtemporaneidad  sancion = new SancionExtemporaneidad(SMLDV, new DateTime(2018, 10, 05));
            decimal valorDeclarar = 100000;
            var fechaDeclaracion = new DateTime(2018, 10, 07);

            //Cuando - Actuar (A)
            decimal respuesta = sancion.Liquidar(valorDeclarar, fechaDeclaracion);
            //Assert(Afirmar)
            Assert.AreEqual(10000, respuesta);
        }
        /// <summary>
        /// 
        ///Dado que el Valor a Declarar es mayor a Cero y con emplazamiento
        ///Cuando Liquide la sanción del monto de 100.000 mil pesos el dia 7-octubre-2018(2 dias)
        ///Entonces la Sanción por extemporaneidad es igual a 20000 pesos
        /// </summary>
        [Test]
        public void SancionExtemporaneidadMayorACeroConEmplazamiento()
        {
            //Arrange(Preparar)
            decimal SMLDV = 781242m / 30m;
            SancionExtemporaneidad sancion = new SancionExtemporaneidad(SMLDV, new DateTime(2018, 10, 05));
            decimal valorDeclarar = 100000;
            var fechaDeclaracion = new DateTime(2018, 10, 07);

            //Cuando - Actuar (A)
            decimal respuesta = sancion.Liquidar(valorDeclarar, fechaDeclaracion, true);
            //Assert(Afirmar)
            Assert.AreEqual(20000, respuesta);
        }
        /// <summary>
        /// 
        ///Dado que el Valor a Declarar es Cero y sin emplazamiento
        ///Cuando Liquide la sanción del monto de 0 pesos el dia 7-octubre-2018(2 dias)
        ///Entonces la Sanción por extemporaneidad es igual a  $ 52.082,80 pesos
        /// </summary>
        [Test]
        public void SancionExtemporaneidadEsCeroSinEmplazamiento()
        {
            //Arrange(Preparar)
            decimal SMLDV = 781242m / 30m;
            SancionExtemporaneidad sancion = new SancionExtemporaneidad(SMLDV, new DateTime(2018, 10, 05));
            decimal valorDeclarar = 0;
            var fechaDeclaracion = new DateTime(2018, 10, 07);

            //Cuando - Actuar (A)
            decimal respuesta = sancion.Liquidar(valorDeclarar, fechaDeclaracion);
            //Assert(Afirmar)
            Assert.AreEqual(52082.80, respuesta);
        }
        /// <summary>
        /// 
        ///Dado que el Valor a Declarar es Cero y con emplazamiento
        ///Cuando Liquide la sanción del monto de 0 pesos el dia 7-octubre-2018(2 dias)
        ///Entonces la Sanción por extemporaneidad es igual a $ 104.165,60      pesos
        /// </summary>
        [Test]
        public void SancionExtemporaneidadEsCeroConEmplazamiento()
        {
            //Arrange(Preparar)
            decimal SMLDV = 781242m / 30m;
            SancionExtemporaneidad sancion = new SancionExtemporaneidad(SMLDV, new DateTime(2018, 10, 05));
            decimal valorDeclarar = 0;
            var fechaDeclaracion = new DateTime(2018, 10, 07);

            //Cuando - Actuar (A)
            decimal respuesta = sancion.Liquidar(valorDeclarar, fechaDeclaracion, true);
            //Assert(Afirmar)
            Assert.AreEqual(104165.60, respuesta);
        }
    }
}
