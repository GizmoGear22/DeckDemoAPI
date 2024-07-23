using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBControllers;
using Models;

namespace LogicLayer.DBLogic
{
	public class DBLogicHandlers : IDBLogicHandlers
	{
		private readonly IAvailableCardsController _availableCardsController;
		public DBLogicHandlers(IAvailableCardsController availableCardsController)
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

		public async Task PostCardToRepository(CardModel model)
		{
			await _availableCardsController.PostNewCardsToDB(model);
		}

		public async Task DeleteCardFromRepository(CardModel card)
		{
			await _availableCardsController.DeleteCardFromDB(card);
		}
	}
}
