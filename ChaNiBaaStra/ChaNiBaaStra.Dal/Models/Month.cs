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
    public class Month : BaseObject
    {
		public Month()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Month") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Month Id")]
		public int MonthId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[Nido.Common.Utilities.Validators.StringLength(250)]
		[DisplayName("Description")]
		public string Description { get; set; }

		[DisplayName("Thithi Months")]
		[ScaffoldColumn(false)]
		public ICollection<ThithiMonth> ThithiMonths { get; set; } 

		[DisplayName("Nakath Months")]
		[ScaffoldColumn(false)]
		public ICollection<NakathMonth> NakathMonths { get; set; } 

		[DisplayName("Rashi Months")]
		[ScaffoldColumn(false)]
		public ICollection<RashiMonth> RashiMonths { get; set; } 

		#endregion

		#region Not Mapped Properties

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
					 && (ThithiMonths.Count > 0)) || ((NakathMonths != null) 
					 && (NakathMonths.Count > 0)) || ((RashiMonths != null) 
					 && (RashiMonths.Count > 0)));
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
				return "<b>" + ((ThithiMonths != null) ? ThithiMonths.Count.ToString() : "Indecisive # of") + "</b> ThithiMonth(s) are using this 'Month'<br/>"
					 + "<b>" + ((NakathMonths != null) ? NakathMonths.Count.ToString() : "Indecisive # of") + "</b> NakathMonth(s) are using this 'Month'<br/>"
					 + "<b>" + ((RashiMonths != null) ? RashiMonths.Count.ToString() : "Indecisive # of") + "</b> RashiMonth(s) are using this 'Month'<br/>"; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return ((ThithiMonths != null) ? ThithiMonths.Count.ToString() : "Indecisive # of")
					 + " ThithiMonth(s), " + ((NakathMonths != null) ? NakathMonths.Count.ToString() : "Indecisive # of")
					 + " NakathMonth(s), " + ((RashiMonths != null) ? RashiMonths.Count.ToString() : "Indecisive # of")
					 + " RashiMonth(s) are using this 'Month'";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(MonthId); } set { MonthId = Convert.ToInt32(value); } }

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
