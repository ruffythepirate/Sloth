using System;

namespace Test2
{
	public class EnvironmentViewModel
	{



		public string Name {
			get;
			set;
		}

		public override string ToString ()
		{
			return string.Format ("[EnvironmentViewModel: Name={0}]", Name);
		}
	}
}

