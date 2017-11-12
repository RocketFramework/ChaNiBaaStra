using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nido.Common.BackEnd;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ChaNiBaaStra.Dal.DB;

namespace ChaNiBaaStra.Dal.Models
{
    /// <summary>
    /// Created by MAS IT
    /// </summary>
    public class GoodThithi : BaseObject
    {
		public GoodThithi()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Good Thithi") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Good Thithi Id")]
		public int GoodThithiId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("PakshaType")]
		[DisplayName("Paksha Type Id")]
		[ScaffoldColumn(false)]
		public Nullable<int> PakshaTypeId { get; set; }

		[DisplayName("Paksha Type")]
		[ScaffoldColumn(false)]
		public PakshaType PakshaType { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("Thithi")]
		[DisplayName("Thithi Id")]
		[ScaffoldColumn(false)]
		public Nullable<int> ThithiId { get; set; }

		[DisplayName("Thithi")]
		[ScaffoldColumn(false)]
		public Thithi Thithi { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("ThithiSagna")]
		[DisplayName("Thithi Sagna Id")]
		[ScaffoldColumn(false)]
		public Nullable<int> ThithiSagnaId { get; set; }

		[DisplayName("Thithi Sagna")]
		[ScaffoldColumn(false)]
		public ThithiSagna ThithiSagna { get; set; } 

		#endregion

		#region Not Mapped Properties

		[NotMapped]
        public string PakshaTypePopup
        {
            get
            {
                if (this.PakshaType != null)
                    return this.CreatePopupText(this.PakshaType.Text
                        , new TableCreator<PakshaType>(this.PakshaType)
                        .RemoveRecord(x => x.Value).RemoveRecord(x => x.Text)
                        .RemoveRecord(x => x.DeleteError).RemoveRecord(x => x.CanDelete)
                        .GetPopupTable());
                else
                    return "Indecisive record data!!";
            }
        }

		[NotMapped]
        public string ThithiPopup
        {
            get
            {
                if (this.Thithi != null)
                    return this.CreatePopupText(this.Thithi.Text
                        , new TableCreator<Thithi>(this.Thithi)
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
                    return true;
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
				return "Click to delete the record."; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return "Click to delete the record.";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(GoodThithiId); } set { GoodThithiId = Convert.ToInt32(value); } }

		
		#endregion
    }
}
