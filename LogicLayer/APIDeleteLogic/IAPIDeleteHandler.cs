using Models;

namespace LogicLayer.APIDeleteLogic
{
	public interface IAPIDeleteHandler
	{
		Task DeleteCard(CardModel model);
	}
}