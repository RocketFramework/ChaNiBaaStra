﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumNakath
    {
        Ashvida = 1,
        Berana = 2,
        Kathi = 3,
        Rehena = 4,
        Msirasa = 5,
        Ada = 6,
        Pwasa = 7,
        Pusha = 8,
        Aslisa = 9,
        Maa = 10,
        Ppal = 11,
        Upal = 12,
        Hatha = 13,
        Sitha = 14,
        Saa = 15,
        Visa = 16,
        Anura = 17,
        Deta = 18,
        Mula = 19,
        Psala = 20,
        Usala = 21,
        Suwana = 22,
        Denata = 23,
        Swasa = 24,
        Pputupa = 25,
        Uputupa = 26,
        Revathi = 27
    }

    public enum EnumRelationshipTypes
    {
        Uchcha = 1,
        UchchaMulaThrikona = 2,
        Swashesthra = 3,
        SwashesthraMulaThrikona = 4,
        Mithra = 5,
        Sama = 6,
        Sathuru = 7,
        SathuruMuta = 8,
        Neecha = 9,
        NeechaMuta = 10,
        SamaMuta = 11,
        MulaThrikona = 12,
        Muta = 13,
        ThathkaalikaMithra = 14,
        Janma = 15,
        Sampath = 16,
        Vipath = 17,
        Kshema = 18,
        Prathyaari = 19,
        Sadhaka = 20,
        Vada = 21,
        Mythree = 22,
        ParamaMythree = 23,
    }
    public class AstroNakath : AstroBase<EnumNakath, Nakath>
    {
        public AstroNakath(EnumNakath nakath) : base(nakath, 27, AstroConsts.NakLength)
        { Init(); }
        public AstroNakath(int nakathPos) : this((EnumNakath)nakathPos)
        { }
        public AstroNakath(double deg)
        { 
            ItemCount = 27;
            Length = AstroConsts.NakLength;     
            Current = this.ofDeg(deg);
            CurrentInt = (int)Current;
            Pada = ((int)(deg / AstroConsts.PadaLength) % 4) + 1;
            Init();
        }
        public void Init()
        {
        }
        public int Pada { get; set; }
        public static List<AstroNakath> ofRasi(AstroRasi rasi)
        {
            int nakIndex = (rasi.CurrentInt / 4) + (rasi.CurrentInt * 2);
            List<AstroNakath> nakathList = new List<AstroNakath>();
            for (int i = nakIndex; i <= nakIndex + 2; i++)
                nakathList.Add(new AstroNakath(i));
            return nakathList;
        }
        public EnumRelationshipTypes RelationshipWith(AstroNakath nakath)
        {
            IntCircle nakCycle = new IntCircle(27, this.CurrentInt);
            Mod nakMod = new Mod(27);
            int id = nakMod.sub(nakath.CurrentInt, this.CurrentInt);

           /*  var id = Math.Abs((this.CurrentInt < nakath.CurrentInt) ?
                27 - (this.CurrentInt - nakath.CurrentInt) :
                nakath.CurrentInt - this.CurrentInt) + 1;*/

            return (EnumRelationshipTypes)(((id % 9) == 0) ? 15 : id % 9 + 15);
        }
        public DateTime? EndTime { get; set; }
        public bool IsGood { get { return !(CurrentInt == 2 || CurrentInt==3||
                    CurrentInt==6||CurrentInt==9||CurrentInt==11||CurrentInt==16||
                    CurrentInt==18||CurrentInt==20||CurrentInt==24||CurrentInt==25); } }
    }
}
