using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
namespace RedisBasicApp
{
    public class BasicSample
    {
        private ConnectionMultiplexer m_Connect = null;
        private string Hash_UserScore_Key = "UserScore";
        public BasicSample()
        {
            string redisConnection = "192.168.8.26,password = 123456,connectTimeout = 60000,syncTimeout = 60000,abortConnect = false";

            m_Connect = ConnectionMultiplexer.Connect(redisConnection);

        }

        //private static ConnectionMultiplexer GetManager(string connectionString = null)
        //{
        //    connectionString = connectionString ?? RedisConnectionString;
        //    var connect = ConnectionMultiplexer.Connect(connectionString);

        //    LogHelper.WriteToLog("获取连接：" + connectionString, "RedisConnectionHelp");

        //    //注册如下事件
        //    connect.ConnectionFailed += MuxerConnectionFailed;
        //    connect.ConnectionRestored += MuxerConnectionRestored;
        //    connect.ErrorMessage += MuxerErrorMessage;
        //    connect.ConfigurationChanged += MuxerConfigurationChanged;
        //    connect.HashSlotMoved += MuxerHashSlotMoved;
        //    connect.InternalError += MuxerInternalError;

        //    return connect;
        //}

        public void HashTest()
        {
            IDatabase database = m_Connect.GetDatabase(0);
            HashEntry[] scoreArray = new HashEntry[100];

            HashEntry current;
            for (int i = 0; i < 100; i++)
            {
                current = new HashEntry($"name{i}", 0);
                scoreArray[i] = current;
            }
            database.HashSet("UserScore", scoreArray);

        }


        public void HashIncrement()
        {
            string hash_key1_key2 = "name0";
            Task[] tasks = new Task[100];
            IDatabase database = m_Connect.GetDatabase(0);
            //database.HashDecrement(Hash_UserScore_Key, "name0");
            //var redisValue =  database.HashGet(Hash_UserScore_Key, "name0");
            //没有创建事务，HashGetAsync，获取可以正常获取Key值
            var redisValue2 = database.HashGetAsync(Hash_UserScore_Key, hash_key1_key2);

            ITransaction transaction = database.CreateTransaction();
            //transaction.AddCondition(Condition.HashEqual(Hash_UserScore_Key, hash_key1_key2), 5);
            Console.WriteLine(redisValue2.Result);
            for (int i = 0; i < 100; i++)
            {
                //Task t = Task.Factory.StartNew(() =>
                //{
                //创建事务之后，没有提交事务，transaction.HashGetAsync 是获取不到值的;
                //创建事务之后，ITransaction.Execute 执行之后命令是打包在一起发送到
                //服务器的，所以ITransacion中执行的查询在Excute之前是拿不到结果的。
                var redisValue1 = transaction.HashGetAsync(Hash_UserScore_Key, hash_key1_key2);

                if (int.Parse(redisValue1.Result.ToString()) % 5 == 0)
                {
                    transaction.HashIncrementAsync(Hash_UserScore_Key, hash_key1_key2);
                }
                //database.HashDecrement(Hash_UserScore_Key, "name0");
                //});
                //tasks[i] = t;
            }


            //Task.WaitAll(tasks);

            transaction.Execute();

        }


        public void HashLockTake()
        {
            string hash_key1_key2 = "name0";
            Task[] tasks = new Task[100];
            IDatabase database = m_Connect.GetDatabase(0);

            //database.loc
        }




    }
}
