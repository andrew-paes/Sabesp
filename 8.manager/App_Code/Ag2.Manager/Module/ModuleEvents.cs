///////////////////////////////////////////////////////////
//  ModuleEvents.cs
//  Implementation of the Class ModuleEvents
//  Generated by Enterprise Architect
//  Created on:      16-out-2006 17:07:35
//  Original author: F�bio Nuno
///////////////////////////////////////////////////////////

using System;
namespace Ag2.Manager.Module
{
    [Serializable]
	public class ModuleEvents {

		private bool _afterRegisterDelete;
		private string _assemblyName;
        private string _className;
		private bool _beforeRegisterDelete;
        		
		public bool AfterRegisterDelete{
			get{
				return _afterRegisterDelete;
			}
			set{
				_afterRegisterDelete = value;
			}
		}

		public string AssemblyName{
			get{
				return _assemblyName;
			}
			set{
				_assemblyName = value;
			}
		}

        public string ClassName
        {
            get
            {
                return _className;
            }
            set
            {
                _className = value;
            }
        }

		public bool BeforeRegisterDelete{
			get{
				return _beforeRegisterDelete;
			}
			set{
				_beforeRegisterDelete = value;
			}
		}

	}//end ModuleEvents

}//end namespace Module