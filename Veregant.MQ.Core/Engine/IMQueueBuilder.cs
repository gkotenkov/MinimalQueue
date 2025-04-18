using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veregant.MQ.Core.Engine
{
	internal interface IMQueueBuilder
	{
		Task<IMQueueBuilder> Build();
		IMQueueBuilder BuildAsync();

	}
}
