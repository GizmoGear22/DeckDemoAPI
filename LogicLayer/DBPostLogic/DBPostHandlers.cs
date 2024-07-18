using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DBAccess.DBControllers;

namespace LogicLayer.DBPostLogic
{
	public class DBPostHandlers : IDBPostHandlers
	{
		private readonly IAvailableCardsController _controller;
		public DBPostHandlers(IAvailableCardsController controller)
		{
			_controller = controller;
		}

		public async Task DBPostHandler(CardModel model)
		{
			await _controller.PostNewCardsToDB(model);
		}
	}
}
