using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.Utility
{
    public class UpperFirstCharacter
    {
        public static CardModel CapitalizeFirstCharacter(CardModel card)
        {
            if (char.IsLower(card.name[0]))
            {
                string[] letterArray = new string[card.name.Length];
                for (int i = 0; i < card.name.Length; i++)
                {
                    letterArray[i] = card.name[i].ToString();
                }
                var newLetter = letterArray[0].ToUpper();
                letterArray[0] = newLetter;
                var name = string.Join("", letterArray);
                card.name = name;

                return card;
            }
            else { return card; }
        }
    }
}
