using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBGetLogic;
using LogicLayer.APIGetLogic;
using Moq;
using Models;
using Xunit;

namespace UnitTests.LogicLayerTests
{
	public class APIGetHandlerTests
	{
		[Fact]
		public async Task GetCardsToAPITest()
		{
			//arrange
			var sample = new SampleCardsLists();
			var sampleList = sample.SampleList();
			var mock = new Mock<IDBGetHandlers>();
			var data = mock.Setup(x => x.GetAllCardsFromRepository()).ReturnsAsync(new List<CardModel>(sampleList));

			//act
			var handler = new APIGetHandlers(mock.Object);
			var result = await handler.GetAllCards();

			//assert
			Assert.NotNull(result);
			Assert.Equal(result, sampleList);
		}
	}
}
