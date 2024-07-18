using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Models;
using LogicLayer.Validation.ValueValidations;

namespace UnitTests.LogicLayerTests.Validations
{

	public class CheckAttackValues
	{

		[Fact]
		public async Task CheckIfAttackLessThanZeroTest()
		{
			//arrange
			var model1 = new CardModel
			{
				cost = 1,
				attack = 1,
				defense = 2
			};

			var model2 = new CardModel
			{
				cost = -2,
				attack = -2,
				defense = -1
			};
			ValueValidations valueValidations = new ValueValidations();

			//act
			var (result1, message1) = await valueValidations.CheckIfAttackLessThanZero(model1);
			var (result2, message2) = await valueValidations.CheckIfAttackLessThanZero(model2);

			//assert
			Assert.True(result1);
			Assert.False(result2);
		}

	}
}
