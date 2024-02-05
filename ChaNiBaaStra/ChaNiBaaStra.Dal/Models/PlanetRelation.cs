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
    public class PlanetRelation : BaseObject
    {
		public PlanetRelation()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Planet Relation") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Planet Relation Id")]
		public int PlanetRelationId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("FocusPlanet")]
		[DisplayName("Focus Planet Id")]
		[ScaffoldColumn(false)]
		public int FocusPlanetId { get; set; }

		[DisplayName("Focus Planet")]
		[ScaffoldColumn(false)]
		public Planet FocusPlanet { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("RelatedPlanet")]
		[DisplayName("Related Planet Id")]
		[ScaffoldColumn(false)]
		public int RelatedPlanetId { get; set; }

		[DisplayName("Related Planet")]
		[ScaffoldColumn(false)]
		public Planet RelatedPlanet { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("RelationshipType")]
		[DisplayName("Relationship Type Id")]
		[ScaffoldColumn(false)]
		public int RelationshipTypeId { get; set; }

		[DisplayName("Relationship Type")]
		[ScaffoldColumn(false)]
		public RelationshipType RelationshipType { get; set; } 

		#endregion

		#region Not Mapped Properties

		[NotMapped]
        public string FocusPlanetPopup
        {
            get
            {
                if (this.FocusPlanet != null)
                    return this.CreatePopupText(this.FocusPlanet.Text
                        , new TableCreator<Planet>(this.FocusPlanet)
                        .RemoveRecord(x => x.Value).RemoveRecord(x => x.Text)
                        .RemoveRecord(x => x.DeleteError).RemoveRecord(x => x.CanDelete)
                        .GetPopupTable());
                else
                    return "Indecisive record data!!";
            }
        }

		[NotMapped]
        public string RelatedPlanetPopup
        {
            get
            {
                if (this.RelatedPlanet != null)
                    return this.CreatePopupText(this.RelatedPlanet.Text
                        , new TableCreator<Planet>(this.RelatedPlanet)
                        .RemoveRecord(x => x.Value).RemoveRecord(x => x.Text)
                        .RemoveRecord(x => x.DeleteError).RemoveRecord(x => x.CanDelete)
                        .GetPopupTable());
                else
                    return "Indecisive record data!!";
            }
        }

		[NotMapped]
        public string RelationshipTypePopup
        {
            get
            {
                if (this.RelationshipType != null)
                    return this.CreatePopupText(this.RelationshipType.Text
                        , new TableCreator<RelationshipType>(this.RelationshipType)
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
		{ get { return Convert.ToString(PlanetRelationId); } set { PlanetRelationId = Convert.ToInt32(value); } }

		
		#endregion
    }
}
