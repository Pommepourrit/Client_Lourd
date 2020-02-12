using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingModel
{
    public partial class Employe
    {
        public string FullName
        {
            get
            {
                return this.Prenom + " " + this.Nom;
            }
        }
    }
}
