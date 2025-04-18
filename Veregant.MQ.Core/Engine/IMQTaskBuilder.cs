using System.Linq.Expressions;
using Veregant.MQ.Core.Models;

namespace Veregant.MQ.Core.Engine
{
	public interface IMQTaskBuilder
	{
		public MQMessage Build();
		public void BuildAndEnqueue();

		public IMQTaskBuilder WithHighPriority();
		public IMQTaskBuilder WithLowPriority();
		public IMQTaskBuilder SetPriority(MQPriority _priority);

		public IMQTaskBuilder WithProcessor(Expression<Func<object, Task>> _expression);
		IMQTaskBuilder WithProcessor(Expression<Action> _expression);
		public IMQTaskBuilder SetCustomTaskName(string _id);

	}

	public class MQTaskBuilder : IMQTaskBuilder
	{
		private MQMessage? Message { get; set; }

		public MQMessage Build()
		{
			try
			{
				Message ??= new MQMessage();

				if(Message.Processor == null) throw new InvalidOperationException("Processor for the task wasn't defined");
			}
			catch (Exception ex)
			{
				throw;
			}
			return Message;
		}

		public IMQTaskBuilder WithHighPriority()
		{
			Message ??= new MQMessage();
			Message.Priority = MQPriority.high;
			return this;
		}

		public IMQTaskBuilder WithLowPriority()
		{

			Message ??= new MQMessage();
			Message.Priority = MQPriority.low;
			return this;
		}

		public IMQTaskBuilder SetPriority(MQPriority _priority)
		{
			Message ??= new MQMessage();
			Message.Priority = _priority;
			return this;
		}

		public IMQTaskBuilder WithProcessor(Expression<Func<object, Task>> _expression)
		{
			if (_expression.Body is not MethodCallExpression call) throw new ArgumentException("Expression must be method call");

			Message ??= new MQMessage();
			Message.Processor = _expression;
			return this;
		}

		public IMQTaskBuilder WithProcessor(Expression<Action> _expression)
		{
			if (_expression.Body is not MethodCallExpression call) throw new ArgumentException("Expression must be method call");

			Message ??= new MQMessage();
			Expression<Func<object, Task>> wrapped = _ => Task.Run(() => _expression);;

			Message.Processor = wrapped;
			return this;
		}

		public IMQTaskBuilder SetCustomTaskName(string _name)
		{
			Message ??= new MQMessage();
			Message.Name = _name;
			return this;
		}

		public void BuildAndEnqueue()
		{
			try
			{
				Message ??= new MQMessage();

				if (Message.Processor == null) throw new InvalidOperationException("Processor for the task wasn't defined"); 
				MQEngine.GetMQEngine().MQStorageEnqueue(Message);
			}
			catch (Exception ex)
			{
				throw;
			}
			
		}
	}
}
