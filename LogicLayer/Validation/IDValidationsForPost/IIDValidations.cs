using Models;

namespace LogicLayer.Validation.IDValidationsForPost
{
	internal interface IIDValidations
	{
		Task<(bool, string)> CheckId(CardModel model);
		Task<(bool, string)> CheckIfIdExists(CardModel model);
		Task<(bool, string)> CheckZeroId(CardModel model);
	}
}