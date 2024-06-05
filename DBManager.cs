using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voltooid.Models;

namespace Voltooid
{
    public class DBManager
    {
        private static ScientistsEntities _ents;

        public static ScientistsEntities GetContext()
        {
            if(_ents == null)
            {
                _ents = new ScientistsEntities();
            }
            
            return _ents;
        }
    }
}
