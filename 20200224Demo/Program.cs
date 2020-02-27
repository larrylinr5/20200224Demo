using _20200224Demo.Mappings;
using _20200224Demo.Models;
using AutoMapper;
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



            //automapper未使用時的程式碼-----------------------------------------
            var amodel = new AModel
            {
                Name = "Jeff",
                No = 123
            };
            var bmodel = new BModel
            {
                Name = amodel.Name,
                No = amodel.No
            };
            //automapper未使用時的程式碼-----------------------------------------

            //加了auto-----------------------------------
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AModel, BModel>());
            var mapper = config.CreateMapper();

            var amodel2 = new AModel
            {
                Name = "Jeff",
                No = 123
            };
            var bmodel3 = mapper.Map<BModel>(amodel2);
            //加了auto-----------------------------------

            //透過AddProfile增加多組mapping----------------------------------------
            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AModel, BModel>();
                cfg.AddProfile<BModelProfile>();
            });
            var mapper2 = config2.CreateMapper();

            var amodel4 = new AModel
            {
                Name = "Jeff",
                No = 123
            };
            var bmodel4 = mapper.Map<BModel>(amodel4);
            //透過AddProfile增加多組mapping----------------------------------------
        }
    }
}
