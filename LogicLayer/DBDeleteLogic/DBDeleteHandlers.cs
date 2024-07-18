using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBControllers;
using Models;

namespace LogicLayer.DBDeleteLogic
{
	public class DBDeleteHandlers : IDBDeleteHandlers
	{
		private readonly IAvailableCardsController _controller;
		public DBDeleteHandlers(IAvailableCardsController controller)
		{
			_controller = controller;
		}
		public async Task DeleteCardFromRepository(CardModel card)
		{
			await _controller.DeleteCardFromDB(card);
		}
	}
}
