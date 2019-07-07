using Ninject.Modules;
using pubnub.publish;

namespace pubnub.logic
{
    public class LogicNinjectModule : NinjectModule
    {
        /// <summary>
        /// Overrding Load method and adding baindings for DI to take into account
        /// </summary>
        public override void Load()
        {
            Bind<IPublisher<int>>().To<Publisher<int>>();
            Bind<IPublisher<string>>().To<Publisher<string>>();
        }
    }
}
