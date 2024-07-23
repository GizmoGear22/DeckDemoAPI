using Models;

namespace LogicLayer.DBLogic
{
	public interface IDBLogicHandlers
	{
		Task PostCardToRepository(CardModel model);
		Task DeleteCardFromRepository(CardModel card);
		Task<IEnumerable<CardModel>> GetAllCardsByTypeRepository(CardType type);
		Task<IEnumerable<CardModel>> GetAllCardsFromRepository();
		Task<CardModel> GetCardByIdFromRepository(int id);
	}
}