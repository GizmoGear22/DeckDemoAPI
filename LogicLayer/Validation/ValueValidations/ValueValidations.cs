using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegateUtilities;
using Models;

namespace LogicLayer.Validation.ValueValidations
{
	public class ValueValidations : IValueValidations
	{
		ValidationDelegate.ValidationMessageDelegate validationMessage = DelegateValidationMessage.ValidationMessage;
		public async Task<(bool, string?)> CheckIfAttackLessThanZero(CardModel card)
		{
			if (card.attack < 0 || card.attack >= 12)
			{
				string message = "Attack number must be greater than zero and less than or equal to 12";
				await validationMessage(message);
				return (false, message);
			}
			else { return (true, null); }
		}

		public async Task<(bool, string?)> CheckIfDefenseLessThanZero(CardModel card)
		{
			if (card.defense < 0 || card.defense >=12)
			{
				string message = "Defense number must be greater than zero and less than or equal to 12";
				await validationMessage(message);
				return (false, message);
			}
			else { return (true, null); }
		}

		public async Task<(bool, string?)> CheckIfCostLessThanZero(CardModel card)
		{
			if (card.cost < 0 || card.cost >= 8)
			{
				string message = "Cost must be greater than zero and less than or equal to 8";
				await validationMessage(message);
				return (false, message);
			}
			else { return (true, null); }
		}
	}
}
