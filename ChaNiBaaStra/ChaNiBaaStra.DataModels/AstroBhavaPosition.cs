using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;

namespace ChaNiBaaStra.DataModels
{
    public class AstroBhavaPosition
    {
        public AstroBhavaPosition(AstroPosition posData)
        {
            Name = posData.AstroPositionId + "). " + posData.Name;
            string[] repList = posData.Representations.Split('#');
            if (repList.Count() > 2)
            {
                GeneralData = repList[0];
                BodyPart = repList[2];
                FamilyMembers = repList[1];
            }
        }
        public string Name { get; set; }
        public string GeneralData { get; set; }
        public string BodyPart { get; set; }
        public string FamilyMembers { get; set; }
    }
}
