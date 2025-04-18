using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veregant.MQ.Core.Models;

namespace Veregant.MQ.Core.Vault
{
	internal class MQInMemoryStorage
	{
		private Dictionary<MQPriority, MQueue> storage { get; set; } = new(); 
		private static readonly object _lock = new();

		private static MQInMemoryStorage inMemoryStorage { get; set; }

		private MQInMemoryStorage() { }

		public static Dictionary<MQPriority, MQueue> GetStorage()
		{
			lock (_lock)
			{
				if (inMemoryStorage == null)
					inMemoryStorage = new MQInMemoryStorage();

				return inMemoryStorage.storage;
			}

		}
	}
}
