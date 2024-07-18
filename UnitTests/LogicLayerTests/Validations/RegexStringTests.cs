using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Validation.CheckName;

namespace UnitTests.LogicLayerTests.Validations
{
	public class RegexStringTests
	{
		[Fact]
		public void RegexDefinitionTest()
		{
			//arrange
			string name = "Bobby Pin";
			string name1 = "@Duck";
			//act
			var result = RegexDefinitions.CheckNameCharacters(name);
			var result1 = RegexDefinitions.CheckNameCharacters(name1);
			//assert
			Assert.True(result);
			Assert.False(result1);
		}
	}
}
