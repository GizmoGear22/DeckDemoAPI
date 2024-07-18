using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using DBAccess.DBControllers;
using Models;

namespace LogicLayer.DBGetLogic
{
	public class DBGetHandlers : IDBGetHandlers
	{
		private readonly IAvailableCardsController _availableCardsController;
		public DBGetHandlers(IAvailableCardsController availableCardsController)
		{
			_availableCardsController = availableCardsController;
		}

		public async Task<IEnumerable<CardModel>> GetAllCardsFromRepository()
		{
			var allCardData = await _availableCardsController.SeeAllCardOptions();
			return allCardData;
		}


		public async Task<IEnumerable<CardModel>> GetAllCardsByTypeRepository(CardType type)
		{
			var data = await _availableCardsController.SeeCardOptionsByType(type);
			return data.ToList();
		}

		public async Task<CardModel> GetCardByIdFromRepository(int id)
		{
			var data = await _availableCardsController.SeeCardById(id);
			return data;
		}
	}
}
