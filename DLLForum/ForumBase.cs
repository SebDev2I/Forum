﻿using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public abstract class ForumBase
    {
        public int Int_NullValue = int.MinValue;
        public static float Float_NullValue = float.MinValue;
        public static decimal Decimal_NullValue = decimal.MinValue;
        public static string String_NullValue = null;
        public static DateTime DateTime_NullValue = DateTime.MinValue;

        public List<ValidationError> ValidationErrors { get; set; }

        public ForumBase()
        {
            ValidationErrors = new List<ValidationError>();
        }
        public abstract List<ValidationError> Validate();
    }
}
