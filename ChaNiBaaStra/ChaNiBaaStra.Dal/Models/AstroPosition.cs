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
    public class AstroPosition : BaseObject
    {
		public AstroPosition()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Astro Position") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Astro Position Id")]
		public int AstroPositionId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Code")]
		public string Code { get; set; }

		[DisplayName("Is Kendra")]
		public Nullable<bool> IsKendra { get; set; }

		[DisplayName("Is Upachaya")]
		public Nullable<bool> IsUpachaya { get; set; }

		[DisplayName("Is Anupachaya")]
		public Nullable<bool> IsAnupachaya { get; set; }

		[DisplayName("Karmasthana Id")]
		public Nullable<int> KarmasthanaId { get; set; }

		[DisplayName("Is Thrikona")]
		public Nullable<bool> IsThrikona { get; set; }

		[DisplayName("Is Panaphara")]
		public Nullable<bool> IsPanaphara { get; set; }

		[DisplayName("Is Apoklima")]
		public Nullable<bool> IsApoklima { get; set; }
        public string Representations { get; set; }
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
		{ get { return Convert.ToString(AstroPositionId); } set { AstroPositionId = Convert.ToInt32(value); } }

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
