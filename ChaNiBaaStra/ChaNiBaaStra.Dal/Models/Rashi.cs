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
    public class Rashi : BaseObject
    {
		public Rashi()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Rashi") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Rashi Id")]
		public int RashiId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[ForeignKey("MovemenType")]
		[DisplayName("Movemen Type Id")]
		[ScaffoldColumn(false)]
		public Nullable<int> MovemenTypeId { get; set; }

		[DisplayName("Movemen Type")]
		[ScaffoldColumn(false)]
		public MovemenType MovemenType { get; set; } 

		[DisplayName("Is Saumya")]
		public Nullable<bool> IsSaumya { get; set; }

		[DisplayName("Is Male")]
		public Nullable<bool> IsMale { get; set; }

		[DisplayName("Is Odd")]
		public Nullable<bool> IsOdd { get; set; }

		[DisplayName("Planet Rashi Relations")]
		[ScaffoldColumn(false)]
		public ICollection<PlanetRashiRelation> PlanetRashiRelations { get; set; } 

		[DisplayName("Rashi Thithis")]
		[ScaffoldColumn(false)]
		public ICollection<RashiThithi> RashiThithis { get; set; } 

		[DisplayName("Rashi Months")]
		[ScaffoldColumn(false)]
		public ICollection<RashiMonth> RashiMonths { get; set; } 

		#endregion

		#region Not Mapped Properties

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
                    return !(((PlanetRashiRelations != null) 
					 && (PlanetRashiRelations.Count > 0)) || ((RashiThithis != null) 
					 && (RashiThithis.Count > 0)) || ((RashiMonths != null) 
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
				return "<b>" + ((PlanetRashiRelations != null) ? PlanetRashiRelations.Count.ToString() : "Indecisive # of") + "</b> PlanetRashiRelation(s) are using this 'Rashi'<br/>"
					 + "<b>" + ((RashiThithis != null) ? RashiThithis.Count.ToString() : "Indecisive # of") + "</b> RashiThithi(s) are using this 'Rashi'<br/>"
					 + "<b>" + ((RashiMonths != null) ? RashiMonths.Count.ToString() : "Indecisive # of") + "</b> RashiMonth(s) are using this 'Rashi'<br/>"; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return ((PlanetRashiRelations != null) ? PlanetRashiRelations.Count.ToString() : "Indecisive # of")
					 + " PlanetRashiRelation(s), " + ((RashiThithis != null) ? RashiThithis.Count.ToString() : "Indecisive # of")
					 + " RashiThithi(s), " + ((RashiMonths != null) ? RashiMonths.Count.ToString() : "Indecisive # of")
					 + " RashiMonth(s) are using this 'Rashi'";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(RashiId); } set { RashiId = Convert.ToInt32(value); } }

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
