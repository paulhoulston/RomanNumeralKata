﻿using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
			var orderedDigits = Digits.OrderByDescending (digit => digit.Key).ToArray();
			for (var i = 0; i < orderedDigits.Length; i++) {
				var digit = orderedDigits [i];
				var multipleOfDigit = (int)(valueToConvert / digit.Key);
				if (multipleOfDigit > 0) {
					return InstancesOfNumeral(multipleOfDigit, digit.Value);
				}
			}
			throw new NotSupportedException (string.Format ("The Roman Numeral could not be parsed from value '{0}'", valueToConvert));
		}

		private string InstancesOfNumeral(int numberOfNumerals, string numeral) {
			var output = "";
			for (var i = 0; i < numberOfNumerals; i++) {
				output += numeral;
			}
			return output;
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
				Assert.AreEqual(expectedOutput, new RomanNumeral ().ConvertFrom (valueToConvert));
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
				Assert.AreEqual(expectedOutput, new RomanNumeral ().ConvertFrom (valueToConvert));
			}
		}

		class when_I_supply_the_value_of_single_roman_numeral_less_than_single_roman_numeral_preceeding_it
		{
			[TestCase(4, "IV")]
			[TestCase(9, "IX")]
			[TestCase(40, "XL")]
			[TestCase(90, "XC")]
			[TestCase(400, "CD")]
			[TestCase(900, "CM")]
			public void then_I_get_the_expected_output(int valueToConvert, string expectedOutput){
				Assert.AreEqual(expectedOutput, new RomanNumeral ().ConvertFrom (valueToConvert));
			}
		}
	}
}
