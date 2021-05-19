using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RedisBasicApp
{
    public class BasicSample
    {
        private ConnectionMultiplexer m_Connect = null;
        private string Hash_UserScore_Key = "{UserScore}";
        public BasicSample()
        {
            string redisConnection = "192.168.8.189,password = 123456,connectTimeout = 60000,syncTimeout = 60000,abortConnect = false";

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


        public Tuple<int,long> HashIncrementScript(string hash_key,string hask_key_key,int maxCounter)
        {
            Tuple<int, long> result = new Tuple<int, long>(0,0);

            IDatabase database = m_Connect.GetDatabase(0);
            const string SCRIPT_INCREMENT = @"
        local result={};
        local balance = 0;
        local operate = 0;
        if (redis.call('hexists', KEYS[1],KEYS[2]) == 1) then
          balance = tonumber(redis.call('hget', KEYS[1],KEYS[2]));
          if ((balance + 1) <= tonumber(ARGV[1])) then
              balance= tonumber(redis.call('hincrby', KEYS[1],KEYS[2], 1));
              operate =1 ;
          end;
        else
          balance= tonumber(redis.call('hincrby', KEYS[1],KEYS[2], 1));
          operate =1 ;
        end;
        result[1] = operate;
        result[2] = balance;
        return result ;
        --return balance;
       
        ";

            //Key列表
            List<RedisKey> keyList = new List<RedisKey>();
            keyList.Add(hash_key);
            keyList.Add(hask_key_key);
           
            //Value 列表
            List<RedisValue> valueList = new List<RedisValue>();
            valueList.Add(maxCounter.ToString());
            //lua脚本中返回不了 return a,b 多值,但是可以返回数组，
     
            //ScriptEvaluate 可以返回单值与多值
            //单值 SingleRedisResult
            //多值 ArrayRedisResult
            //SingleRedisResult,ArrayRedisResult,这两种返回值都是
            //继承RedisResult
            RedisResult redisResult = database.ScriptEvaluate(
                SCRIPT_INCREMENT,
               keyList.ToArray(),
               valueList.ToArray()

               );

            //return long.Parse( redisResult.ToString());
            if(!redisResult.IsNull)
            {
                RedisResult[] redisArray = (RedisResult[])redisResult;
                result = new Tuple<int, long>(int.Parse(redisArray[0].ToString()), long.Parse(redisArray[1].ToString()));
            }


            return result;
            

        }

        /// <summary>
        /// 单个实例在跑，没有出现Score超过1000；
        /// 多个实例跑，很容易出现score超过1000，经常会到 1022;
        /// </summary>
        public void Wath()
        {
            IDatabase database = m_Connect.GetDatabase(11);

            //Wath_Init(database);

            List<Task> taskList = new List<Task>();
            
            for (int j = 0; j < 1000; j++)
            {
                Task t = Task.Factory.StartNew(() =>
                {
                    //IDatabase database1 = m_Connect.GetDatabase(11);
                    Wath_HashIncrement(database);
                });

                taskList.Add(t);

            }

            Task.WaitAll(taskList.ToArray());
            

            //Parallel.For(0, 100, i => {
            //    //Task t = Task.Factory.StartNew(() =>
            //    //{
            //        //IDatabase database1 = m_Connect.GetDatabase(11);
            //        Wath_HashIncrement(database);
            //    //});

            //    //taskList.Add(t);
            //});
            ////Task.WaitAll(taskList.ToArray());
            Console.WriteLine("All task finished");
        }

        private void Wath_Init(IDatabase database)
        {
            //初始化
            string hashKey1 = $"user:{1000}";
            database.HashSet(hashKey1, "score", 0);

            //初始化
            //hashKey1 = $"user:{2000}";
            //database.HashSet(hashKey1, "score", 0);


            
        }

        private void Wath_HashIncrement(IDatabase database)
        {
            int maxValue = 1000;
            string hashKey1 = $"user:{1000}";
            RedisValue redisValue= database.HashGet($"user:{1000}", "score");
            int sleepTime = 100;
            sleepTime = new Random((int)DateTime.Now.Ticks).Next(1000);
            Thread.Sleep(sleepTime);
            if (int.Parse(redisValue.ToString())<maxValue)
            {
                
                //Debug.WriteLine(  database.HashIncrement(hashKey1, "score"));
                Console.WriteLine($"sleepTime:{sleepTime} score:{database.HashIncrement(hashKey1, "score")} running:");
            }

        }


    }


}
