using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.APILogic;
using Moq;
using Models;
using Xunit;
using LogicLayer.DBLogic;
using LogicLayer.Validation.IDValidationsForPost;
using LogicLayer.Validation.CheckName;
using LogicLayer.Validation.ValueValidations;
using Microsoft.Extensions.Logging;

namespace UnitTests.LogicLayerTests
{
	public class APIGetHandlerTests
	{
		private readonly Mock<IDBLogicHandlers> _logicHandlers;
		private readonly Mock<IIDValidations> _idValidation;
		private readonly Mock<ICheckIfNameExists> _checkIfNameExists;
		private readonly Mock<IValueValidations> _valueValidations;
		private readonly Mock<ILogger> _logging;
		public APIGetHandlerTests() 
		{
			_logicHandlers = new Mock<IDBLogicHandlers>();
			_idValidation = new Mock<IIDValidations>();
			_checkIfNameExists = new Mock<ICheckIfNameExists>();
			_valueValidations = new Mock<IValueValidations>();
			_logging = new Mock<ILogger>();
		}
		[Fact]
		public async Task GetCardsToAPITest()
		{
			//arrange
			var sample = new SampleCardsLists();
			var sampleList = sample.SampleList();
			var data = _logicHandlers.Setup(x => x.GetAllCardsFromRepository()).ReturnsAsync(new List<CardModel>(sampleList));

			//act
			var handler = new APILogicHandlers(_idValidation.Object, _checkIfNameExists.Object, _valueValidations.Object, _logging.Object, _logicHandlers.Object);
			var result = await handler.GetAllCards();

			//assert
			Assert.NotNull(result);
			Assert.Equal(result, sampleList);
		}
	}
}
