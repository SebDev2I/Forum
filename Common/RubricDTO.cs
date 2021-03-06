﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Classe dto représentant l'ensemble des données d'une rubrique
    /// </summary>
    public class RubricDTO : DTOBase
    {
        public int IdRubric { get; set; }
        public string NameRubric { get; set; }

        public RubricDTO()
        {
            IdRubric = Int_NullValue;
            NameRubric = String_NullValue;
            IsNew = true;
        }

        public override string ToString()
        {
            return "Id : " + IdRubric
                + " Nom : " + NameRubric;
        }
    }
}
