using System;
using Collection;

namespace DnDDiceThrower { 

	public class DiceThrowGenerator
	{
		private static Random rand = new Random();

		public static string GetResult(int diceType, int count)
		{
			return rand.Next(1, 4).ToString();
		}
	}
}
