using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Veregant.MQ.Core.Models
{
	public class MQMessage : IDisposable
	{
		public Task CompletedTask { get; internal set; }
		internal Guid Id { get; set; } = new Guid();
		internal MQPriority Priority { get; set; }
		public Expression<Func<object, Task>>? Processor { get; set; }
		internal string Name { get; set; }

		public void Dispose()
		{
			Processor = null;
		}
	}

	public class MQProcessorWrapper<T>
	{
	}
}
