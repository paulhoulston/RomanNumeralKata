using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralKata
{
	class RomanNumeral
	{
		private static readonly IDictionary<int, string> Digits = new Dictionary<int, string> {
			{ 1,"I" },
			{ 5,"V" },
			{ 10,"X" },
			{ 50,"L" },
			{ 100,"C" },
			{ 500,"D" },
			{ 1000,"M" },
		};

		public string ConvertFrom (int valueToConvert)
		{
			foreach (var digit in Digits.OrderByDescending(digit => digit.Key)) {
				var multipleOfDigit = (int)(valueToConvert / digit.Key);

				if (multipleOfDigit > 0) {
					return new string (digit.Value [0], multipleOfDigit);
				}
			}
			throw new NotSupportedException (string.Format ("The Roman Numeral could not be parsed from value '{0}'", valueToConvert));
		}
	}

	class given_that_I_want_to_convert_an_integer_to_a_roman_numeral
	{
		class when_I_supply_a_known_roman_digit
		{
			[TestCase(1, "I")]
			[TestCase(5, "V")]
			[TestCase(10, "X")]
			[TestCase(50, "L")]
			[TestCase(100, "C")]
			[TestCase(500, "D")]
			[TestCase(1000, "M")]
			public void then_I_get_the_expected_output(int valueToConvert, string expectedOutput){
				var output = new RomanNumeral().ConvertFrom(valueToConvert);
				Assert.AreEqual(expectedOutput, output);
			}
		}

		class when_I_supply_a_simple_multiple_of_a_known_roman_digit
		{
			[TestCase(2, "II")]
			[TestCase(3, "III")]
			[TestCase(20, "XX")]
			[TestCase(300, "CCC")]
			[TestCase(5000, "MMMMM")]
			public void then_I_get_the_expected_output(int valueToConvert, string expectedOutput){
				var output = new RomanNumeral().ConvertFrom(valueToConvert);
				Assert.AreEqual(expectedOutput, output);
			}
		}

	}
}
