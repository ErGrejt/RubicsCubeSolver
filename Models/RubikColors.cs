using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubicsCube.Models
{
	public class RubikColors
	{
		private static RubikColors _instance;
		private RubikColors()
		{
			UP = new char[9];
			DOWN = new char[9];
			LEFT = new char[9];
			RIGHT = new char[9];
			FRONT = new char[9];
			BACK = new char[9];
		}
		public static RubikColors Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new RubikColors();
				}
				return _instance;
			}
		}
		public char[] UP { get; set; } = new char[9];
		public char[] DOWN { get; set; } = new char[9];
		public char[] LEFT { get; set; } = new char[9];
		public char[] RIGHT { get; set; } = new char[9];
		public char[] FRONT { get; set; } = new char[9];
		public char[] BACK { get; set; } = new char[9];
	}
}
