using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veregant.MQ.Core.Models
{
	internal class MQueue
	{
		public ImmutableQueue<MQMessage> Queue { get; set; }

		public string QName { get; set; }

		public string QPriority { get; set; }
	}
}
