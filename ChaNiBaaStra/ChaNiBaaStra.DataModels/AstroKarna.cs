using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.DataModels;
using Nido.Common.BackEnd;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumKarana
    {
        Bava = 1,
        Balava = 2,
        Kaulava = 3,
        Taitula = 4,
        Garija = 5,
        Vanija = 6,
        Visti = 7,
        Sakuna = 8,
        Chatushpada = 9,
        Naga = 10,
        Kimstughna = 11
    }
    public class AstroKarna : AstroBase<EnumKarana, BaseObject>
    {
        public AstroKarna() 
        {
            this.DataModel = null;
        }
        public AstroKarna(EnumKarana karna) : base(karna, 11, AstroConsts.InvalidIntInput)
        { }
        public AstroKarna(int karnaInt) : base((EnumKarana)karnaInt, 11, AstroConsts.InvalidIntInput)
        { }

        public EnumKarana ofDeg(double sun, double moon)
        {
            Mod mod = new Mod(360);
            double deg = mod.sub(moon, sun);
            return ofDeg(deg);
        }

        public override EnumKarana ofIndex(int index)
        {
            int i = index % 7;
            return (EnumKarana)((i == 0) ? 7 : i);
        }
        /*public EnumKarana[] ofDeg(double sun, double moon)
        {
            Mod mod = new Mod(360);
            double deg = mod.sub(moon, sun);
            return new EnumKarana[] { ofDeg(deg), ofDeg(mod.add(deg, 6)) };
        }*/
        public override EnumKarana ofDeg(double deg)
        {
            EnumKarana karana;

            if (deg > AstroConsts.CHATHURDASI_SECOND_HALF && deg <= AstroConsts.CHATHURDASI_SECOND_HALF + 6.0)
                karana = EnumKarana.Sakuna;
            else if (deg > AstroConsts.CHATHURDASI_SECOND_HALF + 6.0 && deg <= AstroConsts.CHATHURDASI_SECOND_HALF + 12.0)
                karana = EnumKarana.Chatushpada;
            else if (deg > AstroConsts.CHATHURDASI_SECOND_HALF + 12.0 && deg <= AstroConsts.CHATHURDASI_SECOND_HALF + 18.0)
                karana = EnumKarana.Naga;
            else if (deg > 0.0 && deg < 6.0)
                karana = EnumKarana.Kimstughna;
            else
                karana = ofIndex((int)(deg / 6) % 7);

            return karana;
        }

        public bool IsGood
        {
            get
            {
                return (CurrentInt < 7);
            }
        }

        public DateTime? EndTime { get; set; }
    }
}
