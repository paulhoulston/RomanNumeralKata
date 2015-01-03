using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralKata
{
	class RomanNumeral
	{
		private static readonly IDictionary<int, string> Digits = new Dictionary<int, string> {
			{ 1,"I" },
			{ 4,"IV" },
			{ 5,"V" },
			{ 9,"IX" },
			{ 10,"X" },
			{ 40,"XL" },
			{ 50,"L" },
			{ 100,"C" },
			{ 90,"XC" },
			{ 400,"CD" },
			{ 500,"D" },
			{ 900,"CM" },
			{ 1000,"M" }
		};

		public string ConvertFrom (int valueToConvert)
		{
			var output = new StringBuilder();
			var orderedDigits = Digits.OrderByDescending (digit => digit.Key).ToArray();
			for (var i = 0; i < orderedDigits.Length; i++) {
				var digit = orderedDigits [i];
				var multipleOfDigit = (int)(valueToConvert / digit.Key);
				if (multipleOfDigit > 0) {
					InstancesOfNumeral(output, multipleOfDigit, digit.Value);
					valueToConvert -= multipleOfDigit * digit.Key;
				}
			}
			return output.ToString();
		}

		private void InstancesOfNumeral(StringBuilder output, int numberOfNumerals, string numeral) {
			for (var i = 0; i < numberOfNumerals; i++) {
				output.Append(numeral);
			}
		}
	}

	class given_that_I_want_to_convert_an_integer_to_a_roman_numeral
	{
		class when_I_supply_a_value
		{
			[TestCase(1, "I")]
			[TestCase(5, "V")]
			[TestCase(10, "X")]
			[TestCase(50, "L")]
			[TestCase(100, "C")]
			[TestCase(500, "D")]
			[TestCase(1000, "M")]
			[TestCase(2, "II")]
			[TestCase(3, "III")]
			[TestCase(20, "XX")]
			[TestCase(300, "CCC")]
			[TestCase(5000, "MMMMM")]
			[TestCase(4, "IV")]
			[TestCase(9, "IX")]
			[TestCase(40, "XL")]
			[TestCase(90, "XC")]
			[TestCase(400, "CD")]
			[TestCase(900, "CM")]
			[TestCase(49, "XLIX")]
			public void then_I_get_the_expected_output(int valueToConvert, string expectedOutput){
				Assert.AreEqual(expectedOutput, new RomanNumeral ().ConvertFrom (valueToConvert));
			}
		}

	}
}
