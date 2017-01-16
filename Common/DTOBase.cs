using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Classe de propriétés communes
    /// </summary>
    [DataContract]
    public abstract class DTOBase : CommonBase
    {
        /// <summary>
        /// True si dto contient des données nouvellement créées
        /// False si les données ont été tirées de la bdd
        /// </summary>
        public bool IsNew { get; set; }
    }
}
