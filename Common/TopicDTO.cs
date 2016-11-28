﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TopicDTO : DTOBase
    {
        public int IdTopic { get; set; }
        public int IdUser { get; set; }
        public int idRubric { get; set; }
        public DateTime DateTopic { get; set; }
        public string TitleTopic { get; set; }
        public string DescTopic { get; set; }

        public TopicDTO()
        {
            IdTopic = Int_NullValue;
            IdUser = Int_NullValue;
            idRubric = Int_NullValue;
            DateTopic = DateTime_NullValue;
            TitleTopic = String_NullValue;
            DescTopic = String_NullValue;
            IsNew = true;
        }
    }
}