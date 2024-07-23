using Models;

namespace LogicLayer.APILogic
{
	public interface IAPILogicHandlers
	{
		Task DeleteCard(CardModel model);
		Task<List<CardModel>> GetAllCards();
		Task<List<CardModel>> GetAllCardsByType(CardType type);
		Task<CardModel> GetCardById(int id);
		Task<(bool isValid, string? errorMessage)> PostNewCard(CardModel model);
	}
}