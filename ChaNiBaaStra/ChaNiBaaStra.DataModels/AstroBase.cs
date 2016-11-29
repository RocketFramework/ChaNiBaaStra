using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nido.Common.BackEnd;

namespace ChaNiBaaStra.DataModels
{
    public abstract class AstroBase
    {
        public static EnumRasi GetNawamsaRasi(double lengthFromMesha)
        {
            int i = (int)Math.Ceiling(lengthFromMesha / AstroConsts.PadaLength);
            if (i == 0)
                i = 1;
            int j = i % 12;
            if (j == 0) j = 12;
            return (EnumRasi)j;
        }
        public class Interval
        {
            public Interval(double startDeg, double endDeg)
            {
                StartDegree = startDeg;
                EndDegree = endDeg;
            }

            public double StartDegree { get; set; }
            public double EndDegree { get; set; }
        }
    }

    public class AstroBase<T> : AstroBase
    {
        public AstroBase() { }
        public AstroBase(T currentItem, int totalItemCount, double degreeLength)
        {
            Current = currentItem;
            ItemCount = totalItemCount;
            Length = degreeLength;
            Enum value = (Enum)(object)currentItem;
            CurrentInt = Convert.ToInt32(value);
        }

        private string _Name;
        public string Name { get { return string.IsNullOrEmpty(_Name) ? Current.ToString() : _Name; } set { _Name = value; } }
        /// <summary>
        /// What is the item in focus
        /// </summary>
        public T Current { get; set; }
        public string CalculationError { get; set; }
        /// <summary>
        /// Integer representation of the currently focus item
        /// </summary>
        public int CurrentInt { get; set; }
        /// <summary>
        /// Total items include in this 
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// Degree length of this 
        /// </summary>
        public double Length { get; set; }

        public AstroPlace Place { get; set; }
        public virtual T ofIndex(int index)
        {
            Type enumType = typeof(T);
            int i = index % ItemCount;
            Enum value = (Enum)Enum.ToObject(enumType, (i == 0) ? ItemCount : i);
            if (Enum.IsDefined(enumType, value) == false)
                throw new NotSupportedException("Unable to convert value from database to the type: " + enumType.ToString());
            return (T)(object)value;
        }
        /// <summary>
        /// What is the focus item at the given degree position
        /// </summary>
        /// <param name="deg">Degree at the searching position</param>
        /// <returns>Focus Item</returns>
        public virtual T ofDeg(double deg)
        {
            if (Length == -1)
                throw new System.InvalidOperationException("This method is not supported for this object"
                    , new Exception("Length is set to -1, this operation cann't perform with that value setup"));
            return ofIndex((int)Math.Ceiling(deg / Length));
        }
        /// <summary>
        /// Get the degree interval of the currently focus item
        /// </summary>
        /// <param name="focusItem"></param>
        /// <returns></returns>
        public Interval degFor(T focusItem)
        {
            if (Length == -1)
                throw new System.InvalidOperationException("This method is not supported for this object"
                    , new Exception("Length is set to -1, this operation cann't perform with that value setup"));
            Enum value = (Enum)(object)focusItem;
            int enumNumber = Convert.ToInt32(value);
            double itemStart = enumNumber * Length;
            double itemEnd = (enumNumber + 1) * Length;
            return new Interval(itemStart, itemEnd);
        }
        /// <summary>
        /// Returns of the absolute pos from current pos
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public T absolute(int pos)
        {
            Enum value = (Enum)(object)Current;
            int enumNumber = Convert.ToInt32(value);
            return ofIndex(enumNumber + pos);
        }
        public T next()
        {
            return absolute(1);
        }
        public T previous()
        {
            return absolute(-1);
        }
    }
    public class AstroBase<T, E> : AstroBase<T>
        where E: BaseObject
    {
        public AstroBase() { }
        public AstroBase(T currentItem, int totalItemCount, double degreeLength) : base(currentItem, totalItemCount, degreeLength)
        { }

        public AstroBase(T currentItem, int totalItemCount, double degreeLength, AstroPlace place)
            : this(currentItem, totalItemCount, degreeLength)
        {
            this.Place = place;
        }
        public E DataModel { get; set; }
        
    }
}
