
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Cors;
using LogicLayer.APILogic;

namespace APILayer.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class AvailableCardsAPI : Controller
	{
		private readonly IAPILogicHandlers _logicHandlers;
		public AvailableCardsAPI(IAPILogicHandlers logicHandlers)
		{
			_logicHandlers = logicHandlers;
		}

		// GET: ViewAllCards
		[Route("GetAllCards")]
		[HttpGet]

		public async Task<IEnumerable<CardModel>> GetAllCards()
		{
			IEnumerable<CardModel>? getData = null;
			try
			{
				getData = await _logicHandlers.GetAllCards();
			}
			catch (Exception ex) 
			{ 
				throw; 
			};

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
			var getData = await _logicHandlers.GetAllCardsByType(model.type);
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

			var getData = await _logicHandlers.GetCardById(id);
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
			var validationResults = await _logicHandlers.PostNewCard(model);
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
			var card = await _logicHandlers.GetCardById(model.id);
			await _logicHandlers.DeleteCard(card);
			return Ok(model);

		}
	}
}
