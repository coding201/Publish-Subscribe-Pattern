using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using pubnub.logic;
using pubnub.publish;

namespace pubnub.logictest
{
    [TestClass]
    public class PublishLogicTest
    {
        private Mock<IPublisher<int>> _intPublisher;
        private Mock<IPublisher<string>> _stringPublisher;
        private IPublishLogic _publishLogic; 

        [TestInitialize]
        public void Initialize()
        {
            _intPublisher = new Mock<IPublisher<int>>();
            _stringPublisher = new Mock<IPublisher<string>>();
            _publishLogic = new PublishLogic(_intPublisher.Object, _stringPublisher.Object);
        }

        [TestMethod]
        public void Publish_Int_success()
        {
            //Arrange
            _intPublisher.Setup(p => p.PublishData(It.IsAny<int>())).Raises(i => i.EventPublisher += null, new EventArguments<int>(5));

            //Act
            _publishLogic.Publish(5);

        }
    }
}
