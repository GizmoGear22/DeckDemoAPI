using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Models;
using LogicLayer.Utility;

namespace UnitTests.LogicLayerTests
{
	public class UpperFirstCharacterTest
	{
		[Fact]
		public void CapitalizeFirstCharacterTest()
		{
			// Arrange
			CardModel card1 = new CardModel { name = "Gilbert" };
			CardModel card2 = new CardModel { name = "gilbert" };

			// Act
			var result1 = UpperFirstCharacter.CapitalizeFirstCharacter(card1);
			var result2 = UpperFirstCharacter.CapitalizeFirstCharacter(card2);

			// Assert
			Assert.Equal("Gilbert", result1.name);
			Assert.Equal("Gilbert", result2.name);
		}

	}
}
