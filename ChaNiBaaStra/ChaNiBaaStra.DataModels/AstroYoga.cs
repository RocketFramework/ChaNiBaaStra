using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using Nido.Common.BackEnd;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumYoga
    {
        Vkambha = 1,
        Priti = 2,
        Ayushman = 3,
        Saubhagya = 4,
        Sobhana = 5,
        Atiganda = 6,
        Sukarma = 7,
        Dhriti = 8,
        Shula = 9,
        Ganda = 10,
        Vruddhi = 11,
        Dhruma = 12,
        Vyaghatha = 13,
        Harshana = 14,
        Vajra = 15,
        Siddhi = 16,
        Vyatipatha = 17,
        Vaariyan = 18,
        Parigha = 19,
        Shiva = 20,
        Siddha = 21,
        Sadhya = 22,
        Shubha = 23,
        Shubra = 24,
        Bhrahma = 25,
        Mahedra = 26,
        Vaidhruti = 27
    }

    public class AstroYoga : AstroBase<EnumYoga>
    {
        public AstroYoga(EnumYoga yoga) : base(yoga, 27, AstroConsts.InvalidIntInput)
        {
        }
        public AstroYoga(int yogaInt) : this((EnumYoga)yogaInt)
        { }

        public EnumYoga ofDeg(double sun, double moon)
        {
            Mod mod360 = new Mod(360);
            return ofIndex((int)Math.Ceiling((mod360.add(sun, moon)) / AstroConsts.YogaLength));
        }
        public bool IsGood { get {
                return !((CurrentInt == 1)
                      || (CurrentInt == 6) || (CurrentInt == 9)
                      || (CurrentInt == 10) || (CurrentInt == 12)
                      || (CurrentInt == 13) || (CurrentInt == 15)
                      || (CurrentInt == 17) || (CurrentInt == 19)
                      || (CurrentInt == 26) || (CurrentInt == 27));
            } }

        public DateTime? EndTime { get; set; }
    }
}
