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
		private List<MQueue> storage { get; set; }
	}
}
