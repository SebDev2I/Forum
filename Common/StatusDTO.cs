using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Classe dto représentant l'ensemble des données d'un statut
    /// </summary>
    public class StatusDTO : DTOBase
    {
        public int IdStatus { get; set; }
        public string NameStatus { get; set; }

        public StatusDTO()
        {
            IdStatus = Int_NullValue;
            NameStatus = String_NullValue;
            IsNew = true;
        }

        public override string ToString()
        {
            return "Id : " + IdStatus
                + " Name : " + NameStatus;
        }
    }
}
