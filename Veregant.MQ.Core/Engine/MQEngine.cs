using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veregant.MQ.Core.Models;
using Veregant.MQ.Core.Vault;

namespace Veregant.MQ.Core.Engine
{
	public interface IMQEngineBuilder
	{
		void MQStorageEnqueue(MQMessage _task);
	}

	internal class MQEngine
	{
		private static MQEngine Instance { get; set; }

		private static readonly object _lock = new();

		private MQEngine() { }

		public static MQEngine GetMQEngine()
		{
			lock (_lock)
			{
				if (Instance == null)
					Instance = new MQEngine();

				return Instance;
			}

		}

		public void MQStorageEnqueue(MQMessage _message)
		{
			var storage = MQInMemoryStorage.GetStorage();

			if (!storage.TryGetValue(_message.Priority, out var queue))
			{
				queue = MQStorageAddQueue(_message.Priority);
			}

			queue.Queue.Enqueue(_message);
		}


		public MQueue MQStorageAddQueue(MQPriority _mQPriority)
		{
			var queue = new MQueue();
			MQInMemoryStorage.GetStorage().Add(_mQPriority, queue);
			return queue;
		}

		public void StartWorker() { }
	}
}
