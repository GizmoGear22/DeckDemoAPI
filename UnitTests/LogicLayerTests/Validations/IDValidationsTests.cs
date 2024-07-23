using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Models;
using LogicLayer.Validation.IDValidationsForPost;
using Moq;
using LogicLayer.DBLogic;

namespace UnitTests.LogicLayerTests.Validations
{
	public class IDValidationsTests
	{
		[Theory]
		[InlineData(1, "Machine Rifle")]
		[InlineData(2, "Oil Flask")]
		public async Task CheckIDTest(int id, string name)
		{
			//arrange
			CardModel card = new CardModel
			{
				id = id,
				name = name,
			};
			var mock = new Mock<IDBLogicHandlers>();
			mock.Setup(x => x.Equals(card)).Returns(true);

			IDValidations validate = new IDValidations(mock.Object);
			
			//act
			var (result, message) = await validate.CheckId(card);

			//assert
			Assert.True(result);
		}

		[Theory]
		[InlineData(-1, "Obelisk")]
		public async Task CheckIDFalseTest(int id, string name)
		{
			CardModel card = new CardModel
			{
				id = id,
				name = name,
			};
			var mock = new Mock<IDBLogicHandlers>();
			mock.Setup(x => x.Equals(card)).Returns(true);

			IDValidations validate = new IDValidations(mock.Object);

			//act
			var (result, message) = await validate.CheckId(card);
			//assert
			Assert.False(result);
		}
	}
}
