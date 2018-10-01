using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialTDD.Core.Domain
{
    interface ISanciones
    {
        decimal Liquidar(decimal ValorDeclarar, DateTime fechaDeclaracion, bool emplazamiento = false);
    }
}
