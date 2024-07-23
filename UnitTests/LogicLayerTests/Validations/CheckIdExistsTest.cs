using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using LogicLayer.APILogic;
using Models;
using LogicLayer.Validation.IDValidationsForPost;

namespace UnitTests.LogicLayerTests.Validations
{
	public class CheckIdExistsTest
	{
		[Fact]
		public async Task CheckIdTest()
		{
			CardModel tempModel = new CardModel
			{
				id = 1,
				name = "spring rifle"
			};

			//arrange
			var mock = new Mock<IAPILogicHandlers>();
			mock.Setup(x => x.GetCardById(tempModel.id)).ReturnsAsync(tempModel);

			//act
			IDValidations id = new IDValidations(mock.Object);
			var (result, message) = await id.CheckIfIdExists(tempModel);

			//assert
			Assert.False(result, message);
		}


	}
}
