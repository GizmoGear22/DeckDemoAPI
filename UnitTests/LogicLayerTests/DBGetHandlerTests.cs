using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBControllers;
using Models;
using Xunit;
using Moq;
using LogicLayer.APIGetLogic;
using LogicLayer.DBGetLogic;

namespace UnitTests.LogicLayerTests
{
	public class DBGetHandlerTests
	{

		[Fact]
		public async Task GetCardsFromRepositoryTest()
		{
			var sample = new SampleCardsLists();
			var sampleList = sample.SampleList();
			//Arrange
			var mock = new Mock<IAvailableCardsController>();
			var data = mock.Setup(x => x.SeeAllCardOptions()).ReturnsAsync(new List<CardModel>(sampleList));


			//Act

			DBGetHandlers handler = new DBGetHandlers(mock.Object);
			var result = await handler.GetAllCardsFromRepository();


			//Assert
			Assert.NotNull(result);
			Assert.Equal(result, sampleList);

		}

		[Fact]
		public async Task GetCardsFromRepositoryByTypeTest()
		{
			var sample = new SampleCardsLists();
			var sampleList = sample.SampleList();
			var typeSampleList = sample.SampleListByType();

			//arrange
			var mock = new Mock<IAvailableCardsController>();
			mock.Setup(x => x.SeeCardOptionsByType(CardType.Machine)).ReturnsAsync(typeSampleList);

			//act
			DBGetHandlers handler = new DBGetHandlers(mock.Object);
			var result = await handler.GetAllCardsByTypeRepository(CardType.Machine);

			//assert
			Assert.NotNull(result);
			Assert.Equal(result, typeSampleList);
		}
	}
}
