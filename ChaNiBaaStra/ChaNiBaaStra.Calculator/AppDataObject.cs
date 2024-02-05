using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.DataModels;

namespace ChaNiBaaStra.Calculator
{
    public class AppDataObject
    {
        public AppDataObject() { }

        public string Name { get; set; }
        public DateTime BirthDateTime { get; set; }
        public AstroPlace BirthLocation { get; set; }

    }
}
