// See https://aka.ms/new-console-template for more information
using Veregant.MQ.Core;
using Veregant.MQ.Core.Engine;

Console.WriteLine("Hello, World!");

using 
(
	var MyTask = new MQTaskBuilder()
	.SetPriority(MQPriority.high)
	.WithProcessor(() => Console.WriteLine("Task is running"))
	.Build()
);


async Task<int> sum (int a, int b) { return a + b; }

 