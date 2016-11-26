using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALForum
{
    internal class DTOParserFactory
    {
        // GetParser
        internal static DTOParser GetParser(System.Type DTOType)
        {
            switch (DTOType.Name)
            {
                case "RegisteredDTO":
                    return new DTOParser_Registered();
                    break;
                /*case "PostDTO":
                    return new DTOParser_Post();
                    break;
                case "SiteProfileDTO":
                    return new DTOParser_SiteProfile();
                    break;*/
            }
            // Si nous arrivons ici alors c'est que nous n'avons pas réussi à trouver le type correspondant. 
            //Nous levons donc une exception.
            throw new Exception("Unknown Type");
        }
    }
}

