using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBPostLogic;
using LogicLayer.Validation.IDValidationsForPost;
using LogicLayer.Validation.CheckName;
using LogicLayer.Validation.ValueValidations;
using LogicLayer.APIPostLogic;
using Models;
using Microsoft.Extensions.Logging;

namespace LogicLayer.APIPostLogic
{
	public class APIPostHandlers : IAPIPostHandlers
	{
		private readonly IDBPostHandlers _dbPostHandlers;
		private readonly IIDValidations _idValidation;
		private readonly ICheckIfNameExists _checkIfNameExists;
		private readonly IValueValidations _valueValidations;
		private readonly ILogger _logger;
		public APIPostHandlers(IDBPostHandlers dbPostHandlers, IIDValidations idValidation, ICheckIfNameExists checkIfNameExists, IValueValidations valueValidations, ILogger logger)
		{
			_dbPostHandlers = dbPostHandlers;
			_idValidation = idValidation;
			_checkIfNameExists = checkIfNameExists;
			_valueValidations = valueValidations;
			_logger = logger;
		}

		public async Task<(bool isValid, string? errorMessage)> PostNewCard(CardModel model)
		{
			try
			{
				var checker = new (bool isValid, string? errorMessage)[]
{
				await _idValidation.CheckIfIdExists(model),
				await _idValidation.CheckId(model),
				await _idValidation.CheckZeroId(model),
				await _checkIfNameExists.CheckName(model),
				await _checkIfNameExists.CheckNameCharacters(model),
				await _valueValidations.CheckIfCostLessThanZero(model),
				await _valueValidations.CheckIfAttackLessThanZero(model),
				await _valueValidations.CheckIfDefenseLessThanZero(model)
};

				foreach (var result in checker)
				{
					if (!result.isValid)
					{
						return (false, result.errorMessage);
					}
				}
				await _dbPostHandlers.DBPostHandler(model);
				return (true, null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "APIPostHandler Failure");
				throw;
			}

		}
	}
}
