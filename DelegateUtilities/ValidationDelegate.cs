using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Threading.Tasks;

namespace DelegateUtilities
{
	public class ValidationDelegate
	{
		public delegate bool DelegateForValidation(CardModel model);
		public delegate Task ValidationMessageDelegate(string message);
	}
}
