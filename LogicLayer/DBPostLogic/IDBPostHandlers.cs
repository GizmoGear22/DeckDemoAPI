using Models;

namespace LogicLayer.DBPostLogic
{
	public interface IDBPostHandlers
	{
		Task DBPostHandler(CardModel model);
	}
}