using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Models
{
	public class CardModel
	{
		public int id { get; set; }
		public string name { get; set; }
		public CardType type { get; set; }
		public int cost { get; set; }
		public int attack { get; set; }
		public int defense { get; set; }
		public string typeString => type.ToString();
		public string inputType { get; set; }
	}

	public enum CardType
	{
		Machine,
		Pyro,
		Alchemy,
		Tesla,
		Bio,
		Blank
	}
}
