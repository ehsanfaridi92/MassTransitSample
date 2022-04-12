using System.Threading.Tasks;
using CrossCuttingLayer;
using MassTransit;

namespace Microservice.TodoApp.Consumers.Consumers
{
    public class TodoConsumer : IConsumer<Todo>
    {
        private ITest _test;

        public TodoConsumer(ITest test)
        {
            _test = test;
        }

        public async Task Consume(ConsumeContext<Todo> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
            await Task.CompletedTask;
        }
    }
    public interface ITest{}
    public class Test:ITest{}
}
