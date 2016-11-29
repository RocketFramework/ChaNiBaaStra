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
    public class NakathMonth : BaseObject
    {
		public NakathMonth()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Nakath Month") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Nakath Month Id")]
		public int NakathMonthId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("Nakath")]
		[DisplayName("Nakath Id")]
		[ScaffoldColumn(false)]
		public int NakathId { get; set; }

		[DisplayName("Nakath")]
		[ScaffoldColumn(false)]
		public Nakath Nakath { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("Month")]
		[DisplayName("Month Id")]
		[ScaffoldColumn(false)]
		public int MonthId { get; set; }

		[DisplayName("Month")]
		[ScaffoldColumn(false)]
		public Month Month { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("Work")]
		[DisplayName("Work Id")]
		[ScaffoldColumn(false)]
		public int WorkId { get; set; }

		[DisplayName("Work")]
		[ScaffoldColumn(false)]
		public Work Work { get; set; } 

		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Ref")]
		public string Ref { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Is Good")]
		public bool IsGood { get; set; }

		#endregion

		#region Not Mapped Properties

		[NotMapped]
        public string NakathPopup
        {
            get
            {
                if (this.Nakath != null)
                    return this.CreatePopupText(this.Nakath.Text
                        , new TableCreator<Nakath>(this.Nakath)
                        .RemoveRecord(x => x.Value).RemoveRecord(x => x.Text)
                        .RemoveRecord(x => x.DeleteError).RemoveRecord(x => x.CanDelete)
                        .GetPopupTable());
                else
                    return "Indecisive record data!!";
            }
        }

		[NotMapped]
        public string MonthPopup
        {
            get
            {
                if (this.Month != null)
                    return this.CreatePopupText(this.Month.Text
                        , new TableCreator<Month>(this.Month)
                        .RemoveRecord(x => x.Value).RemoveRecord(x => x.Text)
                        .RemoveRecord(x => x.DeleteError).RemoveRecord(x => x.CanDelete)
                        .GetPopupTable());
                else
                    return "Indecisive record data!!";
            }
        }

		[NotMapped]
        public string WorkPopup
        {
            get
            {
                if (this.Work != null)
                    return this.CreatePopupText(this.Work.Text
                        , new TableCreator<Work>(this.Work)
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
		{ get { return Convert.ToString(NakathMonthId); } set { NakathMonthId = Convert.ToInt32(value); } }

		
		#endregion
    }
}
