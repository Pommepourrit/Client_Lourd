using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MegaCastingApp.Utils
{
    public class Utils
    {
        /// <summary>
        /// Exclu les chiffres, les charactères spéciaux
        /// Les lettres accentuées ne sont pas excluses
        /// </summary>
        private Regex onlyNumbers = new Regex(@"[0-9]");

        public bool InputIsInt(int toCheck)
        {
            string str = toCheck.ToString();
            return onlyNumbers.IsMatch(str);
        }
    }
}
