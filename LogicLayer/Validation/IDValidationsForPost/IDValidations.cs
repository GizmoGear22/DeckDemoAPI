using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.APIGetLogic;
using Models;
using DelegateUtilities;

namespace LogicLayer.Validation.IDValidationsForPost
{
	public class IDValidations : IIDValidations
	{
		private readonly IAPIGetHandlers _handlers;
		public IDValidations(IAPIGetHandlers handlers)
		{
			_handlers = handlers;
		}
		ValidationDelegate.ValidationMessageDelegate validationMessage = DelegateValidationMessage.ValidationMessage;

		public async Task<(bool, string?)> CheckId(CardModel model)
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

		public async Task<(bool, string?)> CheckIfIdExists(CardModel model)
		{
			var retrievedModel = await _handlers.GetCardById(model.id);
			if (retrievedModel != null)
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

		public async Task<(bool, string?)> CheckZeroId(CardModel model)
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
