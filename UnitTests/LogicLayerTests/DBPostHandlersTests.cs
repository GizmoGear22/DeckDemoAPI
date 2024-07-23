using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBControllers;
using LogicLayer.DBLogic;
using Models;
using Moq;
using Xunit;

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
			var handler = new DBLogicHandlers(mock.Object);

			//act
			await handler.PostCardToRepository(model);

			//assert
			mock.Verify(x => x.PostNewCardsToDB(model), Times.Once);
		}
	}
}
