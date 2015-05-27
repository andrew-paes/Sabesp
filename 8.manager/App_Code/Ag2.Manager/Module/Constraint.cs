///////////////////////////////////////////////////////////
//  Constraint.cs
//  Implementation of the Class Constraint
//  Generated by Enterprise Architect
//  Created on:      14-set-2006 01:17:09
//  Original author: F�bio Nuno
///////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace Ag2.Manager.Module 
{
	/// <summary>
	/// Constraints para modulos do manager
	/// </summary>
	public class Constraint {

		/// <summary>
		/// Campos que devem ser verificandos na constraint
		/// </summary>
		private IList<ConstraintField> _fields;
		/// <summary>
		/// Nome unico da constraint
		/// </summary>
		private string _name;
		/// <summary>
		/// Tipo da constraint que sera aplicado nos campos
		/// </summary>
		private ConstraintType _type;

        /// <summary>
        /// Construtor da classe
        /// </summary>
		public Constraint(){
            _fields = new List<ConstraintField>();
		}

        #region PROPERTY
        /// <summary>
		/// Campos que devem ser verificandos na constraint
		/// </summary>
		public IList<ConstraintField> Fields{
			get{
				return _fields;
			}
			set{
				_fields = value;
			}
		}

		/// <summary>
		/// Nome unico da constraint
		/// </summary>
		public string Name{
			get{
				return _name;
			}
			set{
				_name = value;
			}
		}

		/// <summary>
		/// Tipo da constraint que sera aplicado nos campos
		/// </summary>
		public ConstraintType Type{
			get{
				return _type;
			}
			set{
				_type = value;
			}
        }
        #endregion

    }//end Constraint

}//end namespace Module