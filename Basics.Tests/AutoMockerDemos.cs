using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Tests
{
    public class AutoMockerDemos
    {
        [Fact]
        public async Task AutoMockerSample()
        {
            var mocker = new AutoMocker();
            mocker.Setup<IWheel, string>(w => w.Name).Returns("NAM");
            mocker.Setup<IWheel, string>(w => w.Surname).Returns("SUR");
            mocker.Setup<IWheel, Task<string>>(w => w.DoAsync(It.IsAny<string>())).ReturnsAsync("ASEN");
            var cr = mocker.CreateInstance<Car>();
            Assert.Equal("NAM", cr.GetWheelName());
            Assert.Equal("SUR12", cr.GetWheelSurName());
            var don = await cr.GetItDoneAsync("aa");
            Assert.Equal("ASEN", don);

            var whMock = mocker.GetMock<IWheel>();
            whMock.Verify(w => w.Name, Times.Once());
        }
    }

    public class Car
    {
        private readonly IWheel wheel;
        private readonly Door door;

        public Car(IWheel Wheel, Door door)
        {
            wheel = Wheel;
            this.door = door;
        }

        public string GetWheelName()
        {
            return wheel.Name;
        }

        internal IEnumerable<char> GetWheelSurName()
        {
            var oniki = door.Add5(7);
            return $"{wheel.Surname}{oniki}";

        }

        internal async Task<string> GetItDoneAsync(string a)
        {
            return await wheel.DoAsync(a);
        }
    }

    public interface IWheel
    {
        public string Name { get; set; }
        string Surname { get; }

        public async Task<string> DoAsync(string a)
        {
            await Task.Delay(10);
            return await Task.FromResult( a + "tete");
        }
    }

    public class Door
    {
        public string Color { get; set; }
        public int Add5(int i)
        {
            return i + 5;
        }
    }
}
