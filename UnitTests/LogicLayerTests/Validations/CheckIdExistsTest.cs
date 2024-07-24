using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Models;
using LogicLayer.Validation.IDValidationsForPost;
using LogicLayer.DBLogic;

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
			var mock = new Mock<IDBLogicHandlers>();
			mock.Setup(x => x.GetCardByIdFromRepository(tempModel.id)).ReturnsAsync(tempModel);

			//act
			IDValidations id = new IDValidations(mock.Object);
			var (result, message) = await id.CheckIfIdExists(tempModel);

			//assert
			Assert.False(result, message);
		}


	}
}
