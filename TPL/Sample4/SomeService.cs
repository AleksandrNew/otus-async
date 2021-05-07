using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sample4
{
    public class SomeService
    {
        internal async Task DoSomeWorkAsync()
        {
            Console.WriteLine("Do some work...");
            await Task.Delay(5000);
        }

        public SomeServiceAwaiter GetAwaiter()
        {
            return new SomeServiceAwaiter(this);
        }
    }

    public class SomeServiceAwaiter : INotifyCompletion
    {
        private readonly Task _task;
        public SomeServiceAwaiter(SomeService someService)
        {
            _task = someService.DoSomeWorkAsync();
        }

        public bool IsCompleted => _task.IsCompleted;

        public void GetResult() => _task.GetAwaiter().GetResult();

        public void OnCompleted(Action continuation)
        {
            _task.ContinueWith(t => continuation);
        }
    }
}
