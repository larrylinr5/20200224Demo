using NLog;
using Unity;
using Unity.RegistrationByConvention;

namespace _20200224Demo
{
    class Program
    {
        //練習一的程式碼註解
        //private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            //--------練習三的程式碼註解----------------------------------------------------------------
            ILogger logger = LogManager.GetCurrentClassLogger();
            IUnityContainer unitycontainer = new UnityContainer(); // 建立物件

            unitycontainer.RegisterTypes(                       //Unity的設定
                     AllClasses.FromLoadedAssemblies(),
                     WithMappings.FromMatchingInterface,
                     WithName.Default,
                     WithLifetime.Hierarchical
                );
            unitycontainer.RegisterInstance<ILogger>(logger); // 注入 客制的注入要再自動地注入後面。

            IClass2 result = unitycontainer.Resolve<IClass2>();//取得實作
            result.DemoMethod();

            //--------練習二的程式碼註解----------------------------------------------------------------
            //ILogger logger = LogManager.GetCurrentClassLogger();
            //IClass2 class1 = new Class2(logger); 
            //class1.DemoMethod();

            //--------練習一的程式碼註解----------------------------------------------------------------
            //logger.Trace("我是追蹤:Trace");
            //logger.Debug("我是偵錯:Debug");
            //logger.Info("我是資訊:Info");
            //logger.Warn("我是警告:Warn");
            //logger.Error("我是錯誤:error");
            //logger.Fatal("我是致命錯誤:Fatal");
        }
    }
}
