namespace LogicLayer.APIGetLogic
{
	public interface IAPIGetHandlers
	{
		Task<List<CardModel>> GetAllCards();
		Task<List<CardModel>> GetAllCardsByType(CardType type);
		Task<CardModel> GetCardById(int id);
	}
}