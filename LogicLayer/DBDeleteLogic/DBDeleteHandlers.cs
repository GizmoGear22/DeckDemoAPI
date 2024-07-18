using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DBDeleteLogic
{
	public class DBDeleteHandlers : IDBDeleteHandlers
	{
		private readonly IAvailableCardsController _controller;
		public DBDeleteHandler(IAvailableCardsController controller)
		{
			_controller = controller;
		}
		public async Task DeleteCardFromRepository(CardModel card)
		{
			await _controller.DeleteCardFromDB(card);
		}
	}
}
