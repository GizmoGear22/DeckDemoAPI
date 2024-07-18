using Models;

namespace LogicLayer.Validation.IDValidationsForPost
{
	public interface IIDValidations
	{
		Task<(bool, string?)> CheckId(CardModel model);
		Task<(bool, string?)> CheckIfIdExists(CardModel model);
		Task<(bool, string?)> CheckZeroId(CardModel model);
	}
}