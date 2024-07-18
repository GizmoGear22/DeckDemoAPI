using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBGetLogic;
using LogicLayer.Validation.CheckName;
using Models;
using Moq;
using Xunit;

namespace UnitTests.LogicLayerTests.Validations
{
	public class CheckIfNameExistsTest
	{
		[Fact]
		public async Task CheckNameCharactersTest()
		{
			//arrange
			CardModel model = new CardModel
			{
				id = 1,
				name = "Test"
			};

			var mock = new Mock<IDBGetHandlers>();
			CheckIfNameExists nameExists = new CheckIfNameExists(mock.Object);
			//act

			var (result, message) = await nameExists.CheckNameCharacters(model);
			//assert
			Assert.True(result);
		}
	}
}
