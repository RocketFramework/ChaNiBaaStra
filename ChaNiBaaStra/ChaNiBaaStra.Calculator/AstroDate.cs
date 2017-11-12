using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Calculator;
using ChaNiBaaStra.Utilities;

namespace ChaNiBaaStra.DataModels
{
    public class AstroTransitDate : CalculationBase
    {
        public AstroTransitDate(AstroPlace locationData, bool IsWithDetails) : base(locationData, IsWithDetails)
        {
        }
    }
}
