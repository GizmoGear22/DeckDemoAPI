using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicLayer.Validation.CheckName
{
	public class RegexDefinitions
	{
		public static bool CheckNameCharacters(string name)
		{
			string pattern = @"^[A-Z0-9][A-Za-z0-9' ]*$";
			if (Regex.IsMatch(name, pattern))
			{
				return true;
			}
			else { return false; }
		}
	}
}
