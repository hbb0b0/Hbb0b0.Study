using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockPricesSample
{
    class MyProgram
    {
       public static void  Run()
        {
            var html = GetResult();

            Console.WriteLine("稍等... 正在下载 cnblogs -> html \r\n");

            var content = html.Result;

            Console.WriteLine(content);
        }

        static Task<string> GetResult()
        {
            GetResult stateMachine = new GetResult();

            stateMachine.builder = AsyncTaskMethodBuilder<string>.Create();

            stateMachine.state = -1;

            stateMachine.builder.Start(ref stateMachine);

            return stateMachine.builder.Task;
        }
    }

    class GetResult : IAsyncStateMachine
    {
        public int state;
        public AsyncTaskMethodBuilder<string> builder;
        private WebClient client;
        private string content;
        private string s3;
        private TaskAwaiter<string> awaiter;

        public void MoveNext()
        {
            var result = string.Empty;
            TaskAwaiter<string> localAwaiter;
            GetResult stateMachine;

            int num = state;

            try
            {
                if (num == 0)
                {
                    localAwaiter = awaiter;
                    awaiter = default(TaskAwaiter<string>);
                    num = state = -1;
                }
                else
                {
                    client = new WebClient();

                    localAwaiter = client.DownloadStringTaskAsync(new Uri("http://cnblogs.com")).GetAwaiter();

                    if (!localAwaiter.IsCompleted)
                    {
                        num = state = 0;
                        awaiter = localAwaiter;
                        stateMachine = this;
                        builder.AwaitUnsafeOnCompleted(ref localAwaiter, ref stateMachine);
                        return;
                    }
                }

                s3 = localAwaiter.GetResult();
                content = s3;
                s3 = null;
                result = content;
            }
            catch (Exception exx)
            {
                state = -2;
                client = null;
                content = null;
                builder.SetException(exx);
            }

            state = -2;
            client = null;
            content = null;
            builder.SetResult(result);
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine) { }
    }
}
