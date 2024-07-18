using Models;

namespace LogicLayer.DBGetLogic
{
	public interface IDBGetHandlers
	{
		Task<IEnumerable<CardModel>> GetAllCardsByTypeRepository(CardType type);
		Task<IEnumerable<CardModel>> GetAllCardsFromRepository();
		Task<CardModel> GetCardByIdFromRepository(int id);
	}
}