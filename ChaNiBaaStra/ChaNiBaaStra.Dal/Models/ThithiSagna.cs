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
    public class ThithiSagna : BaseObject
    {
		public ThithiSagna()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Thithi Sagna") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Thithi Sagna Id")]
		public int ThithiSagnaId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Is Good")]
		public bool IsGood { get; set; }

		[DisplayName("Good Thithis")]
		[ScaffoldColumn(false)]
		public ICollection<GoodThithi> GoodThithis { get; set; } 

		[DisplayName("Thithis")]
		[ScaffoldColumn(false)]
		public ICollection<Thithi> Thithis { get; set; } 

		[DisplayName("Thithi Siddhas")]
		[ScaffoldColumn(false)]
		public ICollection<ThithiSiddha> ThithiSiddhas { get; set; } 

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
                    return !(((GoodThithis != null) 
					 && (GoodThithis.Count > 0)) || ((Thithis != null) 
					 && (Thithis.Count > 0)) || ((ThithiSiddhas != null) 
					 && (ThithiSiddhas.Count > 0)));
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
				return "<b>" + ((GoodThithis != null) ? GoodThithis.Count.ToString() : "Indecisive # of") + "</b> GoodThithi(s) are using this 'ThithiSagna'<br/>"
					 + "<b>" + ((Thithis != null) ? Thithis.Count.ToString() : "Indecisive # of") + "</b> Thithi(s) are using this 'ThithiSagna'<br/>"
					 + "<b>" + ((ThithiSiddhas != null) ? ThithiSiddhas.Count.ToString() : "Indecisive # of") + "</b> ThithiSiddha(s) are using this 'ThithiSagna'<br/>"; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return ((GoodThithis != null) ? GoodThithis.Count.ToString() : "Indecisive # of")
					 + " GoodThithi(s), " + ((Thithis != null) ? Thithis.Count.ToString() : "Indecisive # of")
					 + " Thithi(s), " + ((ThithiSiddhas != null) ? ThithiSiddhas.Count.ToString() : "Indecisive # of")
					 + " ThithiSiddha(s) are using this 'ThithiSagna'";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(ThithiSagnaId); } set { ThithiSagnaId = Convert.ToInt32(value); } }

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
