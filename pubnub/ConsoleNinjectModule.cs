using Ninject.Modules;
using pubnub.logic;

namespace pubnub
{
    public class ConsoleNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPublishLogic>().To<PublishLogic>();
        }
    }
}
