using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nido.Common.BackEnd;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChaNiBaaStra.Dal.Models
{
    /// <summary>
    /// Created by MAS IT
    /// </summary>
    public class Thithi : BaseObject
    {
		public Thithi()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Thithi") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Thithi Id")]
		public int ThithiId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[DisplayName("Day")]
		public Nullable<int> Day { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Is Good")]
		public bool IsGood { get; set; }

		[DisplayName("Thithi Pura Awa Type Id")]
		public Nullable<int> ThithiPuraAwaTypeId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("ThithiSagna")]
		[DisplayName("Thithi Sagna Id")]
		[ScaffoldColumn(false)]
		public Nullable<int> ThithiSagnaId { get; set; }

		[DisplayName("Thithi Sagna")]
		[ScaffoldColumn(false)]
		public ThithiSagna ThithiSagna { get; set; } 

		[DisplayName("Thithi Months")]
		[ScaffoldColumn(false)]
		public ICollection<ThithiMonth> ThithiMonths { get; set; } 

		[DisplayName("Nakath Thithi Week Days")]
		[ScaffoldColumn(false)]
		public ICollection<NakathThithiWeekDay> NakathThithiWeekDays { get; set; } 

		[DisplayName("Nakath Thithis")]
		[ScaffoldColumn(false)]
		public ICollection<NakathThithi> NakathThithis { get; set; } 

		[DisplayName("Rashi Thithis")]
		[ScaffoldColumn(false)]
		public ICollection<RashiThithi> RashiThithis { get; set; } 

		[DisplayName("Good Thithis")]
		[ScaffoldColumn(false)]
		public ICollection<GoodThithi> GoodThithis { get; set; } 

		[DisplayName("Work For Thithis")]
		[ScaffoldColumn(false)]
		public ICollection<WorkForThithi> WorkForThithis { get; set; } 

		[DisplayName("Thithi Week Days")]
		[ScaffoldColumn(false)]
		public ICollection<ThithiWeekDay> ThithiWeekDays { get; set; } 

		#endregion

		#region Not Mapped Properties

		[NotMapped]
        public string ThithiSagnaPopup
        {
            get
            {
                if (this.ThithiSagna != null)
                    return this.CreatePopupText(this.ThithiSagna.Text
                        , new TableCreator<ThithiSagna>(this.ThithiSagna)
                        .RemoveRecord(x => x.Value).RemoveRecord(x => x.Text)
                        .RemoveRecord(x => x.DeleteError).RemoveRecord(x => x.CanDelete)
                        .GetPopupTable());
                else
                    return "Indecisive record data!!";
            }
        }

		/// <summary>
        /// Implement this to prevent or allow the object to be deleted through the base handler.
        /// You need to consider all dependant objects before allowing a object to be deleted.
        /// Therefore please implement this correctly/ accordingly.
        /// </summary>
		[NotMapped] 
		[ScaffoldColumn(false)]
		public override bool CanDelete
        {
            // TODO: Impletement this 
            // Example: return ((StudentCourses != null) && (StudentCourses.Count > 0)) ? false : true;
            get
            {
                if (_canDelete.HasValue)
                    return _canDelete.Value;
                else
                    return !(((ThithiMonths != null) 
					 && (ThithiMonths.Count > 0)) || ((NakathThithiWeekDays != null) 
					 && (NakathThithiWeekDays.Count > 0)) || ((NakathThithis != null) 
					 && (NakathThithis.Count > 0)) || ((RashiThithis != null) 
					 && (RashiThithis.Count > 0)) || ((GoodThithis != null) 
					 && (GoodThithis.Count > 0)) || ((WorkForThithis != null) 
					 && (WorkForThithis.Count > 0)) || ((ThithiWeekDays != null) 
					 && (ThithiWeekDays.Count > 0)));
            }
            set { _canDelete = value; }
        }
        private bool? _canDelete;

		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteError
		{
			get 
			{ 
				return "<b>" + ((ThithiMonths != null) ? ThithiMonths.Count.ToString() : "Indecisive # of") + "</b> ThithiMonth(s) are using this 'Thithi'<br/>"
					 + "<b>" + ((NakathThithiWeekDays != null) ? NakathThithiWeekDays.Count.ToString() : "Indecisive # of") + "</b> NakathThithiWeekDay(s) are using this 'Thithi'<br/>"
					 + "<b>" + ((NakathThithis != null) ? NakathThithis.Count.ToString() : "Indecisive # of") + "</b> NakathThithi(s) are using this 'Thithi'<br/>"
					 + "<b>" + ((RashiThithis != null) ? RashiThithis.Count.ToString() : "Indecisive # of") + "</b> RashiThithi(s) are using this 'Thithi'<br/>"
					 + "<b>" + ((GoodThithis != null) ? GoodThithis.Count.ToString() : "Indecisive # of") + "</b> GoodThithi(s) are using this 'Thithi'<br/>"
					 + "<b>" + ((WorkForThithis != null) ? WorkForThithis.Count.ToString() : "Indecisive # of") + "</b> WorkForThithi(s) are using this 'Thithi'<br/>"
					 + "<b>" + ((ThithiWeekDays != null) ? ThithiWeekDays.Count.ToString() : "Indecisive # of") + "</b> ThithiWeekDay(s) are using this 'Thithi'<br/>"; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return ((ThithiMonths != null) ? ThithiMonths.Count.ToString() : "Indecisive # of")
					 + " ThithiMonth(s), " + ((NakathThithiWeekDays != null) ? NakathThithiWeekDays.Count.ToString() : "Indecisive # of")
					 + " NakathThithiWeekDay(s), " + ((NakathThithis != null) ? NakathThithis.Count.ToString() : "Indecisive # of")
					 + " NakathThithi(s), " + ((RashiThithis != null) ? RashiThithis.Count.ToString() : "Indecisive # of")
					 + " RashiThithi(s), " + ((GoodThithis != null) ? GoodThithis.Count.ToString() : "Indecisive # of")
					 + " GoodThithi(s), " + ((WorkForThithis != null) ? WorkForThithis.Count.ToString() : "Indecisive # of")
					 + " WorkForThithi(s), " + ((ThithiWeekDays != null) ? ThithiWeekDays.Count.ToString() : "Indecisive # of")
					 + " ThithiWeekDay(s) are using this 'Thithi'";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(ThithiId); } set { ThithiId = Convert.ToInt32(value); } }

		/// <summary>
        /// This property set the display name of the items of the combo box that created 
		/// deriving the BaseCombo. You may modify or delete this as required.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Text { get { return Name; } set { Name = value; } }
		
		#endregion
    }
}
