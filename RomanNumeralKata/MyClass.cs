using System;
using NUnit.Framework;

namespace RomanNumeralKata
{
	class RomanNumeral
	{
		public object ConvertFrom (int valueToConvert)
		{
			return "I";
		}
	}

	class given_that_I_want_to_convert_an_integer_to_a_roman_numeral
	{
		class when_I_supply_a_known_roman_digit
		{
			[Test]
			public void then_I_get_the_expected_output(){
				var output = new RomanNumeral().ConvertFrom(1);
				Assert.AreEqual("I", output);
			}
		}
	}
}
