using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Calculator;
using ChaNiBaaStra.Utilities;

namespace ChaNiBaaStra.DataModels
{
    public class AstroTransitDate_old : CalculationBase
    {
        public AstroTransitDate_old(AstroPlace locationData, bool IsWithDetails) : base(locationData, IsWithDetails)
        {
        }
    }
}
