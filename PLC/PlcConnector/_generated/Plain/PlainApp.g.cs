using System;

namespace Plc
{
	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainApp : TcoCore.PlainTcoContext
	{
		System.Single _Increment;
		public System.Single Increment
		{
			get
			{
				return _Increment;
			}

			set
			{
				if (_Increment != value)
				{
					_Increment = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Increment)));
				}
			}
		}

		TcoCore.PlainTcoRemoteTask _Invoke_C_Sharp;
		public TcoCore.PlainTcoRemoteTask Invoke_C_Sharp
		{
			get
			{
				return _Invoke_C_Sharp;
			}

			set
			{
				if (_Invoke_C_Sharp != value)
				{
					_Invoke_C_Sharp = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Invoke_C_Sharp)));
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainApp()
		{
			_Invoke_C_Sharp = new TcoCore.PlainTcoRemoteTask();
		}
	}
}