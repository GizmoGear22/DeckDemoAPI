using LogicLayer.APIGetLogic;
using LogicLayer.APIPostLogic;
using LogicLayer.APIDeleteLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Cors;

namespace APILayer.Controllers
{
	[ApiController]
	[Route("/api/")]
	[DisableCors]
	public class AvailableCardsAPI : Controller
	{
		private readonly IAPIGetHandlers _apiGetHandler;
		private readonly IAPIPostHandlers _postHandler;
		private readonly IAPIDeleteHandler _deleteHandler;
		public AvailableCardsAPI(IAPIGetHandlers apiGetHandlers, IAPIPostHandlers postHandler, IAPIDeleteHandler deleteHandler)
		{
			_apiGetHandler = apiGetHandlers;
			_postHandler = postHandler;
			_deleteHandler = deleteHandler;

		}

		// GET: ViewAllCards
		[Route("GetAllCards")]
		[HttpGet]

		public async Task<IEnumerable<CardModel>> GetAllCards()
		{
			var getData = await _apiGetHandler.GetAllCards();

			return getData.ToList();
		}

		//Get: ViewCardsByType
		[Route("GetAllCardByType")]
		[HttpGet]
		public async Task<IActionResult> GetAllCardsByType(string type)
		{
			CardModel model = new CardModel();
			model.inputType = type;
			if (Enum.TryParse(typeof(CardType), model.inputType, out var outputType))
			{
				model.type = (CardType)outputType;
			}
			else
			{
				return BadRequest("Type must be of a Machine, Pyro, Alchemy, Tesla or Bio");
			}
			var getData = await _apiGetHandler.GetAllCardsByType(model.type);
			if (getData == null || !getData.Any())
			{
				return NotFound("Card Doesn't Exist");
			}
			else
			{
				return Ok(getData.ToList());
			}
		}

		//Get: ViewCardById
		[Route("GetCardByID")]
		[HttpGet]
		public async Task<IActionResult> GetCardById(int id)
		{
			if (id == 0 || id < 0)
			{
				return BadRequest("Id must be greater than zero");
			}

			var getData = await _apiGetHandler.GetCardById(id);
			if (getData != null)
			{
				return Ok(getData);
			}
			else
			{
				return BadRequest("Card must exist");
			}

		}

		// POST: Post new cards to Database
		[Route("PostNewCard")]
		[HttpPost]
		public async Task<IActionResult> PostNewCard([FromBody] CardModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Model must be valid");
			}
			if (model == null)
			{
				return BadRequest("Model must not be null");
			}
			if (Enum.TryParse(typeof(CardType), model.inputType, out var type))
			{
				model.type = (CardType)type;
			}
			var validationResults = await _postHandler.PostNewCard(model);
			if (!validationResults.isValid)
			{
				return BadRequest(validationResults.errorMessage);
			}

			return Ok(model);

		}

		//DELETE: Delete card
		[Route("DeleteCard")]
		[HttpDelete]
		public async Task<IActionResult> DeleteCard(CardModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Item must be valid");
			}
			if (model == null)
			{
				return BadRequest("Item must not be null");
			}
			var card = await _apiGetHandler.GetCardById(model.id);
			await _deleteHandler.DeleteCard(card);
			return Ok(model);

		}
	}
}
