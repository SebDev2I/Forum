using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Classe dto représentant l'ensemble des données d'une formation
    /// </summary>
    public class TrainingDTO : DTOBase
    {
        public int IdTraining { get; set; }
        public string NameTraining { get; set; }

        public TrainingDTO()
        {
            IdTraining = Int_NullValue;
            NameTraining = String_NullValue;
            IsNew = true;
        }

        public override string ToString()
        {
            return "Id : " + IdTraining 
                + " Name : " + NameTraining;
        }
    }
}
