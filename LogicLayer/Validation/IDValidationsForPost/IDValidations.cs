﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.APIGetLogic;

namespace LogicLayer.Validation.IDValidationsForPost
{
	internal class IDValidations : IIDValidations
	{
		private readonly IAPIGetHandlers _handlers;
		public IdValidation(IAPIGetHandlers handlers)
		{
			_handlers = handlers;
		}
		ValidationDelegates.ValidationMessageDelegate validationMessage = DelegateValidationMessage.ValidationMessage;

		public async Task<(bool, string)> CheckId(CardModel model)
		{

			if (model.id <= 0)
			{
				string message = "Can't have ID Number less than or equal to 0";
				await validationMessage(message);
				return (false, message);
			}
			else
			{
				return (true, null);
			}
		}

		public async Task<(bool, string)> CheckIfIdExists(CardModel model)
		{
			var retrievedModel = await _handlers.GetCardById(model.id);
			if (retrievedModel.id != 0)
			{
				string message = "ID already exists";
				await validationMessage(message);
				return (false, message);
			}
			else
			{
				return (true, null);
			}
		}

		public async Task<(bool, string)> CheckZeroId(CardModel model)
		{
			if (model.id == 0)
			{
				string message = "ID cannot be 0";
				await validationMessage(message);
				return (false, message);
			}
			else
			{
				return (true, null);
			}
		}


	}
}