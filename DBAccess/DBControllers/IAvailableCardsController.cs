using Models;

namespace DBAccess.DBControllers
{
	public interface IAvailableCardsController
	{
		Task<int> DeleteCardFromDB(CardModel model);
		Task<int> PostNewCardsToDB(CardModel model);
		Task<List<CardModel>> SeeAllCardOptions();
		Task<CardModel> SeeCardById(int id);
		Task<List<CardModel>> SeeCardOptionsByType(CardType param);
	}
}