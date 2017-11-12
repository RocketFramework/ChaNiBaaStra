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
    public class Nakath : BaseObject
    {
		public Nakath()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Nakath") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Nakath Id")]
		public int NakathId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Is Good")]
		public bool IsGood { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(250)]
		[DisplayName("Description")]
		public string Description { get; set; }

		[InverseProperty("FocusNakath")]
		[DisplayName("Focus Nakath Nakath Relations")]
		[ScaffoldColumn(false)]
		public ICollection<NakathRelation> FocusNakathNakathRelations { get; set; } 

		[InverseProperty("RelatedNakath")]
		[DisplayName("Related Nakath Nakath Relations")]
		[ScaffoldColumn(false)]
		public ICollection<NakathRelation> RelatedNakathNakathRelations { get; set; } 

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
                    return !(((FocusNakathNakathRelations != null) 
					 && (FocusNakathNakathRelations.Count > 0)) || ((RelatedNakathNakathRelations != null) 
					 && (RelatedNakathNakathRelations.Count > 0)));
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
				return "<b>" + ((FocusNakathNakathRelations != null) ? FocusNakathNakathRelations.Count.ToString() : "Indecisive # of") + "</b> FocusNakathNakathRelation(s) are using this 'Nakath'<br/>"
					 + "<b>" + ((RelatedNakathNakathRelations != null) ? RelatedNakathNakathRelations.Count.ToString() : "Indecisive # of") + "</b> RelatedNakathNakathRelation(s) are using this 'Nakath'<br/>"; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return ((FocusNakathNakathRelations != null) ? FocusNakathNakathRelations.Count.ToString() : "Indecisive # of")
					 + " FocusNakathNakathRelation(s), " + ((RelatedNakathNakathRelations != null) ? RelatedNakathNakathRelations.Count.ToString() : "Indecisive # of")
					 + " RelatedNakathNakathRelation(s) are using this 'Nakath'";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(NakathId); } set { NakathId = Convert.ToInt32(value); } }

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
