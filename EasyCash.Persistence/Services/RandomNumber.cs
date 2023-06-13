using EasyCash.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Persistence.Services
{
	public class RandomNumber : IRandomNumber
	{
		public int GenerateNumber()
		{
			Random random = new Random();
			return random.Next(10000,1000000);
		}
	}
}
