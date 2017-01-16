using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLLForumV2
{
    /// <summary>
    /// Classe de base permettant d'affecter des valeurs null et générer une liste d'erreur lors de la validation de mes propriétés de classe
    /// </summary>
    public abstract class ForumBase
    {
        public static int Int_NullValue = int.MinValue;
        public static float Float_NullValue = float.MinValue;
        public static decimal Decimal_NullValue = decimal.MinValue;
        public static string String_NullValue = null;
        public static DateTime DateTime_NullValue = DateTime.MinValue;
        public List<ValidationError> ValidationErrors { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ForumBase()
        {
            ValidationErrors = new List<ValidationError>();
        }
        /// <summary>
        /// Méthode abstraite retournant une liste de ValidationError
        /// </summary>
        /// <returns></returns>
        public abstract List<ValidationError> Validate();
    }
}

