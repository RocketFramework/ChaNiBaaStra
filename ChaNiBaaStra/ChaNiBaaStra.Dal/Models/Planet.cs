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
    public class Planet : BaseObject
    {
		public Planet()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Planet") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Planet Id")]
		public int PlanetId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("PlanetaryGenderType")]
		[DisplayName("Planetary Gender Type Id")]
		[ScaffoldColumn(false)]
		public Nullable<int> PlanetaryGenderTypeId { get; set; }

		[DisplayName("Planetary Gender Type")]
		[ScaffoldColumn(false)]
		public PlanetaryGenderType PlanetaryGenderType { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("ButhaType")]
		[DisplayName("Butha Type Id")]
		[ScaffoldColumn(false)]
		public Nullable<int> ButhaTypeId { get; set; }

		[DisplayName("Butha Type")]
		[ScaffoldColumn(false)]
		public ButhaType ButhaType { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("MovemenType")]
		[DisplayName("Movemen Type Id")]
		[ScaffoldColumn(false)]
		public Nullable<int> MovemenTypeId { get; set; }

		[DisplayName("Movemen Type")]
		[ScaffoldColumn(false)]
		public MovemenType MovemenType { get; set; } 

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Is Good")]
		public bool IsGood { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Body Part")]
		public string BodyPart { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Flavor")]
		public string Flavor { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Butha Element")]
		public string ButhaElement { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Color")]
		public string Color { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Gem")]
		public string Gem { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Metal")]
		public string Metal { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Life Style")]
		public string LifeStyle { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Family")]
		public string Family { get; set; }

		[InverseProperty("HeadPlanet")]
		[DisplayName("Head Planet Week Days")]
		[ScaffoldColumn(false)]
		public ICollection<WeekDay> HeadPlanetWeekDays { get; set; } 

		[InverseProperty("RelatedPlanet")]
		[DisplayName("Related Planet Planet Relations")]
		[ScaffoldColumn(false)]
		public ICollection<PlanetRelation> RelatedPlanetPlanetRelations { get; set; } 

		[InverseProperty("FocusPlanet")]
		[DisplayName("Current Planet Relation with Other Planets")]
		[ScaffoldColumn(false)]
		public ICollection<PlanetRelation> FocusPlanetPlanetRelations { get; set; } 

		#endregion

		#region Not Mapped Properties

		[NotMapped]
        public string PlanetaryGenderTypePopup
        {
            get
            {
                if (this.PlanetaryGenderType != null)
                    return this.CreatePopupText(this.PlanetaryGenderType.Text
                        , new TableCreator<PlanetaryGenderType>(this.PlanetaryGenderType)
                        .RemoveRecord(x => x.Value).RemoveRecord(x => x.Text)
                        .RemoveRecord(x => x.DeleteError).RemoveRecord(x => x.CanDelete)
                        .GetPopupTable());
                else
                    return "Indecisive record data!!";
            }
        }

		[NotMapped]
        public string ButhaTypePopup
        {
            get
            {
                if (this.ButhaType != null)
                    return this.CreatePopupText(this.ButhaType.Text
                        , new TableCreator<ButhaType>(this.ButhaType)
                        .RemoveRecord(x => x.Value).RemoveRecord(x => x.Text)
                        .RemoveRecord(x => x.DeleteError).RemoveRecord(x => x.CanDelete)
                        .GetPopupTable());
                else
                    return "Indecisive record data!!";
            }
        }

		[NotMapped]
        public string MovemenTypePopup
        {
            get
            {
                if (this.MovemenType != null)
                    return this.CreatePopupText(this.MovemenType.Text
                        , new TableCreator<MovemenType>(this.MovemenType)
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
                    return !(((HeadPlanetWeekDays != null) 
					 && (HeadPlanetWeekDays.Count > 0)) || ((RelatedPlanetPlanetRelations != null) 
					 && (RelatedPlanetPlanetRelations.Count > 0)) || ((FocusPlanetPlanetRelations != null) 
					 && (FocusPlanetPlanetRelations.Count > 0)));
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
				return "<b>" + ((HeadPlanetWeekDays != null) ? HeadPlanetWeekDays.Count.ToString() : "Indecisive # of") + "</b> HeadPlanetWeekDay(s) are using this 'Planet'<br/>"
					 + "<b>" + ((RelatedPlanetPlanetRelations != null) ? RelatedPlanetPlanetRelations.Count.ToString() : "Indecisive # of") + "</b> RelatedPlanetPlanetRelation(s) are using this 'Planet'<br/>"
					 + "<b>" + ((FocusPlanetPlanetRelations != null) ? FocusPlanetPlanetRelations.Count.ToString() : "Indecisive # of") + "</b> FocusPlanetPlanetRelation(s) are using this 'Planet'<br/>"; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return ((HeadPlanetWeekDays != null) ? HeadPlanetWeekDays.Count.ToString() : "Indecisive # of")
					 + " HeadPlanetWeekDay(s), " + ((RelatedPlanetPlanetRelations != null) ? RelatedPlanetPlanetRelations.Count.ToString() : "Indecisive # of")
					 + " RelatedPlanetPlanetRelation(s), " + ((FocusPlanetPlanetRelations != null) ? FocusPlanetPlanetRelations.Count.ToString() : "Indecisive # of")
					 + " FocusPlanetPlanetRelation(s) are using this 'Planet'";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(PlanetId); } set { PlanetId = Convert.ToInt32(value); } }

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
