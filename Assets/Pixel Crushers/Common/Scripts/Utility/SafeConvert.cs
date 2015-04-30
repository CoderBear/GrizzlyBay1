using UnityEngine;
using System;
using System.Collections.Generic;

namespace PixelCrushers
{

	/// <summary>
	/// Conversion methods that return default values instead of throwing exceptions.
	/// </summary>
	public static class SafeConvert
	{

		public static int ToInt(string s)
		{
			int result;
			return int.TryParse(s, out result) ? result : 0;
		}

		public static float ToFloat(string s)
		{
			float result;
			return float.TryParse(s, out result) ? result : 0;
		}
		
	}

}
