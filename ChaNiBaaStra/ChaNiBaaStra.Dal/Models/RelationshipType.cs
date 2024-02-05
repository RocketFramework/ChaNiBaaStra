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
    public enum EnumRelationshipTypes
    {
        Uchcha = 1,
        UchchaMulaThrikona = 2,
        Swashesthra = 3,
        SwashesthraMulaThrikona = 4,
        Mithra = 5,
        Sama = 6,
        Sathuru = 7,
        SathuruMuta = 8,
        Neecha = 9,
        NeechaMuta = 10,
        SamaMuta = 11,
        MulaThrikona = 12,
        Muta = 13,
        ThathkaalikaMithra = 14,
        Janma = 15,
        Sampath = 16,
        Vipath = 17,
        Kshema = 18,
        Prathyaari = 19,
        Sadhaka = 20,
        Vada = 21,
        Mythree = 22,
        ParamaMythree = 23,
    }

    /// <summary>
    /// Created by MAS IT
    /// </summary>
    public class RelationshipType : BaseObject
    {
		public RelationshipType()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Relationship Type") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Relationship Type Id")]
		public int RelationshipTypeId { get; set; }

		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[DisplayName("Planet Relations")]
		[ScaffoldColumn(false)]
		public ICollection<PlanetRelation> PlanetRelations { get; set; } 

		[DisplayName("Nakath Relations")]
		[ScaffoldColumn(false)]
		public ICollection<NakathRelation> NakathRelations { get; set; } 

		[DisplayName("Planet Rashi Relations")]
		[ScaffoldColumn(false)]
		public ICollection<PlanetRashiRelation> PlanetRashiRelations { get; set; } 

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
                    return !(((PlanetRelations != null) 
					 && (PlanetRelations.Count > 0)) || ((NakathRelations != null) 
					 && (NakathRelations.Count > 0)) || ((PlanetRashiRelations != null) 
					 && (PlanetRashiRelations.Count > 0)));
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
				return "<b>" + ((PlanetRelations != null) ? PlanetRelations.Count.ToString() : "Indecisive # of") + "</b> PlanetRelation(s) are using this 'RelationshipType'<br/>"
					 + "<b>" + ((NakathRelations != null) ? NakathRelations.Count.ToString() : "Indecisive # of") + "</b> NakathRelation(s) are using this 'RelationshipType'<br/>"
					 + "<b>" + ((PlanetRashiRelations != null) ? PlanetRashiRelations.Count.ToString() : "Indecisive # of") + "</b> PlanetRashiRelation(s) are using this 'RelationshipType'<br/>"; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return ((PlanetRelations != null) ? PlanetRelations.Count.ToString() : "Indecisive # of")
					 + " PlanetRelation(s), " + ((NakathRelations != null) ? NakathRelations.Count.ToString() : "Indecisive # of")
					 + " NakathRelation(s), " + ((PlanetRashiRelations != null) ? PlanetRashiRelations.Count.ToString() : "Indecisive # of")
					 + " PlanetRashiRelation(s) are using this 'RelationshipType'";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(RelationshipTypeId); } set { RelationshipTypeId = Convert.ToInt32(value); } }

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
