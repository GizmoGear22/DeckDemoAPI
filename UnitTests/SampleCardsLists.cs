using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace UnitTests
{
	public class SampleCardsLists
	{
		public List<CardModel> SampleList()
		{
			var output = new List<CardModel>
			{
				new CardModel
				{
					id = 1,
					name = "spring rifle",
					type = CardType.Machine,
					attack = 2,
					defense = 1
				},

				new CardModel
				{
					id = 2,
					name = "fire flask",
					type = CardType.Pyro,
					attack = 3,
					defense = 0
				},

				new CardModel
				{
					id = 3,
					name = "Gear Grinder",
					type = CardType.Machine ,
					attack = 4,
					defense = 1
				}
			};
			return output;
		}

		public List<CardModel> SampleListByType()
		{
			var output = new List<CardModel>
			{
				new CardModel
				{
					id = 1,
					name = "spring rifle",
					type = CardType.Machine,
					attack = 2,
					defense = 1
				},
				new CardModel
				{
					id = 3,
					name = "Gear Grinder",
					type = CardType.Machine,
					attack = 4,
					defense = 1
				}
			};
			return output;
		}
	}
}
