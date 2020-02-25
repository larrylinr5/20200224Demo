using NLog;


namespace _20200224Demo
{
    public class Class2 : IClass2
    {
        private readonly ILogger _Logger;
        public Class2(ILogger logger) 
        {
            this._Logger = logger;
        }
        public void DemoMethod()
        {
            this._Logger.Trace("我是追蹤:Trace");
            this._Logger.Debug("我是偵錯:Debug");
            this._Logger.Info("我是資訊:Info");
            this._Logger.Warn("我是警告:Warn");
            this._Logger.Error("我是錯誤:error");
            this._Logger.Fatal("我是致命錯誤:Fatal");
        }
    }
}
