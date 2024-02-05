using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class BirthDataSaveObject
    {
        public BirthDataSaveObject()
        {
            BirthPlace = new AstroPlace();
            TransitPlace = new AstroPlace();
        }

        public BirthDataSaveObject(AstroPlace birthPlace, AstroPlace transitPlace)
        {
            BirthPlace = birthPlace;
            TransitPlace = transitPlace;
        }
        public AstroPlace BirthPlace { get; set; }
        public AstroPlace TransitPlace { get; set; }
    }
}
