
namespace LogicLayer.Validation.ValueValidations
{
	public interface IValueValidations
	{
		Task<(bool, string)> CheckIfAttackLessThanZero(CardModel card);
		Task<(bool, string)> CheckIfCostLessThanZero(CardModel card);
		Task<(bool, string)> CheckIfDefenseLessThanZero(CardModel card);
	}
}