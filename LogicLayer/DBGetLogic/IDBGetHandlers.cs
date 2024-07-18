namespace LogicLayer.DBGetLogic
{
	internal interface IDBGetHandlers
	{
		Task<IEnumerable<CardModel>> GetAllCardsByTypeRepository(CardType type);
		Task<IEnumerable<CardModel>> GetAllCardsFromRepository();
		Task<CardModel> GetCardByIdFromRepository(int id);
	}
}