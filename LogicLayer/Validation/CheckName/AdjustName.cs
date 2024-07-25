using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.Validation.CheckName
{
	public class AdjustName
	{
		public CardModel CapitalizeFirstCharacter(CardModel card)
		{
			if (char.IsLower(card.name[0]))
			{
				card.name =  card.name.ToUpper();
				return card;
			}
			else { return card; }
		}
	}
}
