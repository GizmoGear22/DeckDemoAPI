﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.APIPostLogic
{
	public class APIPostHandlers : IAPIPostHandlers
	{
		private readonly IDBPostHandlers _dbPostHandlers;
		private readonly IIdValidation _idValidation;
		private readonly ICheckIfNameExists _checkIfNameExists;
		private readonly IValueValidations _valueValidations;
		public APIPostHandler(IDBPostHandlers dbPostHandlers, IIdValidation idValidation, ICheckIfNameExists checkIfNameExists, IValueValidations valueValidations)
		{
			_dbPostHandlers = dbPostHandlers;
			_idValidation = idValidation;
			_checkIfNameExists = checkIfNameExists;
			_valueValidations = valueValidations;
		}

		public async Task<(bool isValid, string errorMessage)> PostNewCard(CardModel model)
		{
			var checker = new (bool isValid, string errorMessage)[]
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
	}
}