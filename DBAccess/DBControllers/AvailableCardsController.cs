using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBAccessPoint;

namespace DBAccess.DBControllers
{
	public class AvailableCardsController : IAvailableCardsController
	{
		private readonly IDBCardAccess _connectionHandler;
		public AvailableCardsController(IDBCardAccess connectionHandler)
		{
			_connectionHandler = connectionHandler;
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
