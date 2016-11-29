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
    public class PlanetRelativeView : BaseObject
    {
		public PlanetRelativeView()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Planet Relative View") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Planet Relative View Id")]
		public int PlanetRelativeViewId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("Planet")]
		[DisplayName("Planet Id")]
		[ScaffoldColumn(false)]
		public int PlanetId { get; set; }

		[DisplayName("Planet")]
		[ScaffoldColumn(false)]
		public Planet Planet { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Relative Position")]
		public int RelativePosition { get; set; }

		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Ref")]
		public string Ref { get; set; }

		#endregion

		#region Not Mapped Properties

		[NotMapped]
        public string PlanetPopup
        {
            get
            {
                if (this.Planet != null)
                    return this.CreatePopupText(this.Planet.Text
                        , new TableCreator<Planet>(this.Planet)
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
		{ get { return Convert.ToString(PlanetRelativeViewId); } set { PlanetRelativeViewId = Convert.ToInt32(value); } }

		
		#endregion
    }
}
