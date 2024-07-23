using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Models;
using System.Security.Cryptography.X509Certificates;
using LogicLayer.Validation.IDValidationsForPost;
using LogicLayer.Validation.CheckName;
using LogicLayer.Validation.ValueValidations;
using LogicLayer.APILogic;
using Microsoft.Extensions.Logging;
using LogicLayer.DBLogic;

namespace UnitTests.LogicLayerTests
{
	public class APIPostHandlerTests
	{
		private readonly Mock<IDBLogicHandlers> _logicHandlers;
		private readonly Mock<IIDValidations> _idValidation;
		private readonly Mock<ICheckIfNameExists> _checkIfNameExists;
		private readonly Mock<IValueValidations> _valueValidations;
		private readonly Mock<ILogger> _logging;
		public APIPostHandlerTests() 
		{
			_logicHandlers = new Mock<IDBLogicHandlers>();
			_idValidation = new Mock<IIDValidations>();
			_checkIfNameExists = new Mock<ICheckIfNameExists>();
			_valueValidations = new Mock<IValueValidations>();
			_logging = new Mock<ILogger>();
		}
		[Fact]
		public void APIPostHandlerTest()
		{
			//arrange
			var model = new CardModel
			{
				id = 1,
				name = "Machine Rifle"
			};

			var handler = new APILogicHandlers(_idValidation.Object, _checkIfNameExists.Object, _valueValidations.Object, _logging.Object, _logicHandlers.Object);

			//act
			_idValidation.Setup(x => x.CheckId(model)).ReturnsAsync((true, null));
			_idValidation.Setup(x => x.CheckIfIdExists(model)).ReturnsAsync((true, null));
			_idValidation.Setup(x => x.CheckZeroId(model)).ReturnsAsync((true, null));
			_checkIfNameExists.Setup(x => x.CheckName(model)).ReturnsAsync((true, null));
			_checkIfNameExists.Setup(x => x.CheckNameCharacters(model)).ReturnsAsync((true, null));
			_valueValidations.Setup(x => x.CheckIfCostLessThanZero(model)).ReturnsAsync((true, null));
			_valueValidations.Setup(x => x.CheckIfAttackLessThanZero(model)).ReturnsAsync((true, null));
			_valueValidations.Setup(x => x.CheckIfDefenseLessThanZero(model)).ReturnsAsync((true, null));

			var result = handler.PostNewCard(model);

			//assert
			_logicHandlers.Verify(x => x.PostCardToRepository(model), Times.Once);
		}
	}
}
