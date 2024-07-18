
namespace LogicLayer.APIPostLogic
{
	public interface IAPIPostHandlers
	{
		Task<(bool isValid, string errorMessage)> PostNewCard(CardModel model);
	}
}