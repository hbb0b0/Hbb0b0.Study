using System;
using System.Threading.Tasks;

namespace AsyncFunctionCodeSample
{
    /// <summary>
    /// 异步事件返回为void ,无法等待可以用 TaskCompletionSource
    /// </summary>
    public class NaiveButton
    {
        public event EventHandler? Clicked;

        public void Click()
        {
            Console.WriteLine("Somebody has clicked a button. Let's raise the event...");
            Clicked?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("All listeners are notified.");
        }
    }

    public class AsyncVoidExample:IRun
    {


        static readonly TaskCompletionSource<bool> s_tcs = new TaskCompletionSource<bool>();

        public static async Task MultipleEventHandlersAsync()
        {
            Task<bool> secondHandlerFinished = s_tcs.Task;

            var button = new NaiveButton();

            button.Clicked += OnButtonClicked1;
            //返回void 的异步方法，没有办法等待。事件只会返回void,也不可能返回Task
            button.Clicked += OnButtonClicked2Async;
            button.Clicked += OnButtonClicked3;

            Console.WriteLine("Before button.Click() is called...");
            button.Click();
            Console.WriteLine("After button.Click() is called...");

            await secondHandlerFinished;
        }

        private static void OnButtonClicked1(object? sender, EventArgs e)
        {
            Console.WriteLine("   Handler 1 is starting...");
            Task.Delay(100).Wait();
            Console.WriteLine("   Handler 1 is done.");
        }

        private static async void OnButtonClicked2Async(object? sender, EventArgs e)
        {
            Console.WriteLine("   Handler 2 is starting...");
            Task.Delay(100).Wait();
            Console.WriteLine("   Handler 2 is about to go async...");
            await Task.Delay(500);
            Console.WriteLine("   Handler 2 is done.");
            s_tcs.SetResult(true);
        }

        private static void OnButtonClicked3(object? sender, EventArgs e)
        {
            Console.WriteLine("   Handler 3 is starting...");
            Task.Delay(100).Wait();
            Console.WriteLine("   Handler 3 is done.");
        }

        public void Run()
        {
           var t=     MultipleEventHandlersAsync();
            t.Wait();
        }
    }
    // Example output:
    //
    // Before button.Click() is called...
    // Somebody has clicked a button. Let's raise the event...
    //    Handler 1 is starting...
    //    Handler 1 is done.
    //    Handler 2 is starting...
    //    Handler 2 is about to go async...
    //    Handler 3 is starting...
    //    Handler 3 is done.
    // All listeners are notified.
    // After button.Click() is called...
    //    Handler 2 is done.
}