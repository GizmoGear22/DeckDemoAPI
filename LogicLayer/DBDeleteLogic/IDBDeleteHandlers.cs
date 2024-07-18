using Models;

namespace LogicLayer.DBDeleteLogic
{
	public interface IDBDeleteHandlers
	{
		Task DeleteCardFromRepository(CardModel card);
	}
}