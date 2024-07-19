using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBAccessPoint;
using Models;
using Microsoft.Extensions.Logging;

namespace DBAccess.DBControllers
{
	public class AvailableCardsController : IAvailableCardsController
	{
		private readonly IDBCardAccess _connectionHandler;
		private readonly ILogger _logger;
		public AvailableCardsController(IDBCardAccess connectionHandler, ILogger logger)
		{
			_connectionHandler = connectionHandler;
			_logger = logger;
		}

		public async Task<List<CardModel>> SeeAllCardOptions()
		{
			try
			{
				string sql = "Select * from dbo.AvailableCards";
				var allCards = await _connectionHandler.DBGetConnectionHandler<CardModel>(sql);
				return allCards;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				_logger.LogError(ex, "Didn't get it in DBAccess");
				throw;
			}
		}

		public async Task<List<CardModel>> SeeCardOptionsByType(CardType param)
		{
			string sql = "Select * from dbo.AvailableCards where type = @type";
			var allCards = await _connectionHandler.DBGetConnectionHandlerByType<CardModel>(sql, param);
			return allCards;
		}

		public async Task<CardModel> SeeCardById(int id)
		{
			string sql = "Select * from dbo.AvailableCards where id = @id";
			var card = await _connectionHandler.GetConnectionHandlerById<CardModel>(sql, id);
			return card;
		}

		public async Task<int> PostNewCardsToDB(CardModel model)
		{
			string sql = "INSERT INTO [dbo].[AvailableCards]([id],[name],[type],[cost],[attack],[defense]) Values (@id, @name, @type,@cost, @attack, @defense)";
			var param =
			new
			{
				id = model.id,
				name = model.name,
				type = model.type,
				cost = model.cost,
				attack = model.attack,
				defense = model.defense
			};
			var data = await _connectionHandler.DBPostConnectionHandler(sql, param);
			return data;
		}

		public async Task<int> DeleteCardFromDB(CardModel model)
		{
			string sql = "DELETE FROM [dbo].[AvailableCards] WHERE [id] = @id";
			var param = new { id = model.id };
			var data = await _connectionHandler.DBPostConnectionHandler(sql, param);
			return data;
		}

	}
}
