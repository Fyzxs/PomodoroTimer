using InterfaceMocks.Reflection;
using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests
{
    public class CreateTheTestsHere
    {
        private CountdownTimerUpdateAction_FormToTop forTheReference;
        private ChainValidation chainValidation = new ChainValidation();
        TimerProgress timeProgress = TimerProgress.Last;
        MockMainForm mockMainForm = new MockMainForm.Builder().Build();
        private PrivateCtor<object> ctor;

        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            //CLASS subject = new CLASS(nextAction);

            //// Act
            //subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrder()
        {
            ////Arrange
            //ChainValidation chainValidation = new ChainValidation()
            //    .Add<EXAMPLE>();

            ////Act
            //CLASS subject = new CLASS();

            ////Assert
            //chainValidation.AssertExpectedChain(subject);
        }
        //[TestClass]
        //public class Tests
        //{
        //    [TestMethod, TestCategory("unit")]
        //    public void ShouldBringFormToTop()
        //    {
        //        //Arrange
        //        TimerProgress timeProgress = TimerProgress.Last;
        //        MockMainForm mockMainForm = new MockMainForm.Builder().Build();
        //        MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
        //        MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();
        //        CountdownTimerUpdateAction_FormToTop subject = new CountdownTimerUpdateAction_FormToTop(nextAction);

        //        //Act
        //        subject.Act(mockMainForm, mockCountdownTime, timeProgress);

        //        //Assert
        //        nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        //    }
        //}
    }
}