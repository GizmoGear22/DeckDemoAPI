using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBLogic;
using LogicLayer.Validation.CheckName;
using LogicLayer.Validation.IDValidationsForPost;
using LogicLayer.Validation.ValueValidations;
using Microsoft.Extensions.Logging;
using Models;

namespace LogicLayer.APILogic
{
	public class APILogicHandlers : IAPILogicHandlers
	{
		private readonly IIDValidations _idValidation;
		private readonly ICheckIfNameExists _checkIfNameExists;
		private readonly IValueValidations _valueValidations;
		private readonly ILogger _logger;
		private readonly IDBLogicHandlers _logicHandlers;
		public APILogicHandlers(IIDValidations idValidation, ICheckIfNameExists checkIfNameExists, IValueValidations valueValidations, ILogger logger, IDBLogicHandlers logicHandlers)
		{
			_idValidation = idValidation;
			_checkIfNameExists = checkIfNameExists;
			_valueValidations = valueValidations;
			_logicHandlers = logicHandlers;
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
				await _logicHandlers.PostCardToRepository(model);
				return (true, null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "APIPostHandler Failure");
				throw;
			}
		}

		public async Task<List<CardModel>> GetAllCards()
		{
			var dataList = await _logicHandlers.GetAllCardsFromRepository();
			return dataList.ToList();
		}

		public async Task<List<CardModel>> GetAllCardsByType(CardType type)
		{
			var dataList = await _logicHandlers.GetAllCardsByTypeRepository(type);
			return dataList.ToList();
		}

		public async Task<CardModel> GetCardById(int id)
		{
			return await _logicHandlers.GetCardByIdFromRepository(id);
		}

		public async Task DeleteCard(CardModel model)
		{
			(bool, string?)[] checker =
{
				await _idValidation.CheckIfIdExists(model),
				await _idValidation.CheckId(model),
				await _checkIfNameExists.CheckName(model),
				await _checkIfNameExists.CheckNameCharacters(model)
			};

			if (checker.All(c => c.Item1))
			{
				await _logicHandlers.DeleteCardFromRepository(model);
			}

		}
	}
}
