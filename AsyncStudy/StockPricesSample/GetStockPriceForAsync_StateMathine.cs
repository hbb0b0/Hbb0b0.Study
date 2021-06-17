using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockPricesSample
{
    class GetStockPriceForAsync_StateMachine
    {
        enum State { Start, Step1, }
        private readonly StockPrices @this;
        private readonly string _companyId;
        private readonly TaskCompletionSource<decimal> _tcs;
        private Task _initializeMapIfNeededTask;
        private State _state = State.Start;

        public GetStockPriceForAsync_StateMachine(StockPrices @this, string companyId)
        {
            this.@this = @this;
            _companyId = companyId;
        }

        public void Start()
        {
            try
            {
                if (_state == State.Start)
                {
                    // 从方法的开始到第一个“await”的代码

                    if (string.IsNullOrEmpty(_companyId))
                        throw new ArgumentNullException();

                    _initializeMapIfNeededTask = @this.InitializeMapIfNeeded();

                    // 更新状态并注册回调函数
                    _state = State.Step1;
                    _initializeMapIfNeededTask.ContinueWith(_ => Start());
                }
                else if (_state == State.Step1)
                {
                    // 需要先检查错误和是否被取消
                    if (_initializeMapIfNeededTask.Status == TaskStatus.Canceled)
                        _tcs.SetCanceled();
                    else if (_initializeMapIfNeededTask.Status == TaskStatus.Faulted)
                        _tcs.SetException(_initializeMapIfNeededTask.Exception.InnerException);
                    else
                    {
                        // 从第一个await到方法结束的代码

                        @this._stockPrices.TryGetValue(_companyId, out var result);
                        _tcs.SetResult(result);
                    }
                }
            }
            catch (Exception e)
            {
                _tcs.SetException(e);
            }
        }

        public Task<decimal> Task => _tcs.Task;

        public Task<decimal> GetStockPriceForAsync(string companyId)
        {
            var stateMachine = new GetStockPriceForAsync_StateMachine(@this, companyId);
            stateMachine.Start();
            return stateMachine.Task;
        }
    }

   
}
