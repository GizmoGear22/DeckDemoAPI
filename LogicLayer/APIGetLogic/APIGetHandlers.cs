using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Models;
using LogicLayer.DBGetLogic;

namespace LogicLayer.APIGetLogic
{
	public class APIGetHandlers : IAPIGetHandlers
	{
		private readonly IDBGetHandlers _dbGetHandlers;
		public APIGetHandlers(IDBGetHandlers dbGetHandlers)
		{
			_dbGetHandlers = dbGetHandlers;
		}
		public async Task<List<CardModel>> GetAllCards()
		{
			var dataList = await _dbGetHandlers.GetAllCardsFromRepository();
			return dataList.ToList();
		}

		public async Task<List<CardModel>> GetAllCardsByType(CardType type)
		{
			var dataList = await _dbGetHandlers.GetAllCardsByTypeRepository(type);
			return dataList.ToList();
		}

		public async Task<CardModel> GetCardById(int id)
		{
			return await _dbGetHandlers.GetCardByIdFromRepository(id);
		}
	}
}
