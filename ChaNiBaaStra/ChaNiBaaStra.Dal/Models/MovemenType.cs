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
    public class MovemenType : BaseObject
    {
		public MovemenType()
			// Change this parameter to change the DisplayName 
			// (this name is used in all system messages)
			// property of this object
			: base("Movemen Type") { }

		#region Public Properties
		[Key]
		[Nido.Common.Utilities.Validators.Required]
		[DisplayName("Movemen Type Id")]
		public int MovemenTypeId { get; set; }

		[Nido.Common.Utilities.Validators.Required]
		[Nido.Common.Utilities.Validators.StringLength(50)]
		[DisplayName("Name")]
		public string Name { get; set; }

		[DisplayName("Rashis")]
		[ScaffoldColumn(false)]
		public ICollection<Rashi> Rashis { get; set; } 

		[DisplayName("Planets")]
		[ScaffoldColumn(false)]
		public ICollection<Planet> Planets { get; set; } 

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
                    return !(((Rashis != null) 
					 && (Rashis.Count > 0)) || ((Planets != null) 
					 && (Planets.Count > 0)));
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
				return "<b>" + ((Rashis != null) ? Rashis.Count.ToString() : "Indecisive # of") + "</b> Rashi(s) are using this 'MovemenType'<br/>"
					 + "<b>" + ((Planets != null) ? Planets.Count.ToString() : "Indecisive # of") + "</b> Planet(s) are using this 'MovemenType'<br/>"; 
			} 
		}
		
		[NotMapped]
		[ScaffoldColumn(false)]
		public override string DeleteErrorText
		{
			get 
			{ 
				return ((Rashis != null) ? Rashis.Count.ToString() : "Indecisive # of")
					 + " Rashi(s), " + ((Planets != null) ? Planets.Count.ToString() : "Indecisive # of")
					 + " Planet(s) are using this 'MovemenType'";
			} 
		}

		/// <summary>
        /// This property set the value of the items of the combo box that created 
		/// deriving the BaseCombo. You may change this as needed.
        /// </summary>
        [NotMapped]
		[ScaffoldColumn(false)]
        public override string Value 
		{ get { return Convert.ToString(MovemenTypeId); } set { MovemenTypeId = Convert.ToInt32(value); } }

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
