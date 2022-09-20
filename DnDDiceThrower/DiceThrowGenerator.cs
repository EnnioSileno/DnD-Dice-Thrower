using System;
using System.Collections.Generic;

namespace DnDDiceThrower { 

	public class DiceThrowGenerator
	{
		private static Random rand = new Random();

		public static List<int> GetResult(int diceType, int numberOfRolls) {
			List<int> result = new List<int>();
			for (int i = 0; i < numberOfRolls; i++) {
				result.Add(rand.Next(1, diceType + 1));
			}
			return result;
		}
	}
}
