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
		ImmutableQueue<MQTask> Queue { get; set; }
		
		string QName { get; set; }

		string QPriority { get; set; }
	}
}
