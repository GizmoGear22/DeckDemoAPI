using Models;

namespace LogicLayer.Validation.CheckName
{
	public interface ICheckIfNameExists
	{
		Task<(bool, string?)> CheckName(CardModel model);
		Task<(bool, string?)> CheckNameCharacters(CardModel model);
	}
}