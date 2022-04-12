using System.Threading.Tasks;
using CrossCuttingLayer;
using MassTransit;

namespace WorkerServiceMassTransit.Consumers
{
    public class TodoConsumer11 : IConsumer<Todo11>
    {
        private ITest11 _test;

        public TodoConsumer11(ITest11 test)
        {
            _test = test;
        }

        public async Task Consume(ConsumeContext<Todo11> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
            await Task.CompletedTask;
        }
    }
    public interface ITest11{}
    public class Test11:ITest11{}
}
