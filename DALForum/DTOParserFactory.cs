using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALForum
{
    public class DTOParserFactory
    {
        // GetParser
        public static DTOParser GetParser(System.Type DTOType)
        {
            switch (DTOType.Name)
            {
                case "MessageDTO":
                    return new DTOParser_Message();
                case "RegisteredDTO":
                    return new DTOParser_Registered();
                case "RubricDTO":
                    return new DTOParser_Rubric();
                case "StatusDTO":
                    return new DTOParser_Status();
                case "TopicDTO":
                    return new DTOParser_Status();
                case "TrainingDTO":
                    return new DTOParser_Training();
            }
            // Si nous arrivons ici alors c'est que nous n'avons pas réussi à trouver le type correspondant. 
            //Nous levons donc une exception.
            throw new Exception("Unknown Type");
        }
    }
}

