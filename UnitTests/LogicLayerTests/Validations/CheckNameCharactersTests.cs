using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using LogicLayer.Validation.CheckName;
using Moq;
using LogicLayer.DBGetLogic;
using Models;

namespace UnitTests.LogicLayerTests.Validations
{
	public class CheckNameCharactersTests
	{
		[Fact]
		public async Task MatchNameTest()
		{
			//arrange
			var sample = new SampleCardsLists();
			var sampleList = sample.SampleList();
			var mock = new Mock<IDBGetHandlers>();
			mock.Setup(x => x.GetAllCardsFromRepository()).ReturnsAsync(new List<CardModel>(sampleList));

			CheckIfNameExists checkName = new CheckIfNameExists(mock.Object);

			CardModel tempModel = new CardModel
			{
				name = "Garbage"
			};

			//act
			var (result, message) = await checkName.CheckName(tempModel);

			//assert
			Assert.True(result);
		}
		[Fact]
		public async Task MatchNameFalseTest()
		{
			//arrange
			var sample = new SampleCardsLists();
			var sampleList = sample.SampleList();
			var mock = new Mock<IDBGetHandlers>();
			mock.Setup(x => x.GetAllCardsFromRepository()).ReturnsAsync(new List<CardModel>(sampleList));

			CheckIfNameExists checkName = new CheckIfNameExists(mock.Object);

			CardModel tempModel = new CardModel
			{
				name = "spring rifle"
			};

			//act
			var (result, message) = await checkName.CheckName(tempModel);

			//assert
			Assert.False(result);
		}
	}
}
