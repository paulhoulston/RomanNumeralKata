using System;
using NUnit.Framework;

namespace RomanNumeralKata
{
	public class MyClass
	{
		public MyClass ()
		{
		}
	}

	class given_that_I_want_to_convert_an_integer_to_a_roman_numeral
	{
		class when_I_supply_a_known_roman_digit
		{
			[Test]
			public void then_I_get_the_expected_output(){
				var output = "";
				Assert.AreEqual("I", output);
			}
		}
	}
}
