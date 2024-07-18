using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBControllers;
using LogicLayer.APIPostLogic;
using Models;
using Moq;

namespace UnitTests.LogicLayerTests
{
	public class DBPostHandlersTests
	{
		[Fact]
		public async Task DBPostHandlerTest()
		{
			//arrange
			CardModel model = new CardModel();
			var mock = new Mock<IAvailableCardsController>();
			var handler = new DBPostHandlers(mock.Object);

			//act
			await handler.DBPostHandler(model);

			//assert
			mock.Verify(x => x.PostNewCardsToDB(model), Times.Once);
		}
	}
}
