using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    /// <summary>
    /// Classe permettant d'assigner des erreurs de validation
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Nom de la propriété concernée par l'erreur
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Information au sujet de l'erreur
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// Liste de ValidationError
        /// </summary>
        public List<ValidationError> ValidationErrors { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ValidationError() { }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="propertyname"></param>
        /// <param name="information"></param>
        public ValidationError(string propertyname, string information) : this()
        {
            PropertyName = propertyname;
            Information = information;
        }

    }
}
