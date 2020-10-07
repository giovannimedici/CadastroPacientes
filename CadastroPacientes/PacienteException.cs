using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPacientes
{
    class PacienteException:Exception
    {
        public PacienteException(string msg):base(msg)
        {
        }
    }
}
