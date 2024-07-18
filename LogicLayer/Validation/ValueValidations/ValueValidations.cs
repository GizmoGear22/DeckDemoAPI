using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Validation.ValueValidations
{
	public class ValueValidations : IValueValidations
	{
		ValidationDelegates.ValidationMessageDelegate validationMessage = DelegateValidationMessage.ValidationMessage;
		public async Task<(bool, string)> CheckIfAttackLessThanZero(CardModel card)
		{
			if (card.attack < 0)
			{
				string message = "Attack number must be greater than zero";
				await validationMessage(message);
				return (false, message);
			}
			else { return (true, null); }
		}

		public async Task<(bool, string)> CheckIfDefenseLessThanZero(CardModel card)
		{
			if (card.defense < 0)
			{
				string message = "Defense number must be greater than zero";
				await validationMessage(message);
				return (false, message);
			}
			else { return (true, null); }
		}

		public async Task<(bool, string)> CheckIfCostLessThanZero(CardModel card)
		{
			if (card.cost < 0)
			{
				string message = "Cost must be greater than zero";
				await validationMessage(message);
				return (false, message);
			}
			else { return (true, null); }

		}
	}
}
