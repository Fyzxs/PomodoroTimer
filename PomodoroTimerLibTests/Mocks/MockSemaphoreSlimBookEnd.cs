using InterfaceMocks;
using PomodoroTimerLib.Library.Threading;
using System;
using System.Threading.Tasks;

namespace PomodoroTimerLibTests.Mocks
{
    public partial class MockSemaphoreSlimBookEnd : ISemaphoreSlimBookEnd
    {
        private MockMethod _wait;
        private MockMethod _waitSync;
        private MockMethod _release;
        private MockSemaphoreSlimBookEnd() { }
        public Task Wait() => _wait.InvokeTask();
        public void WaitSync() => _waitSync.Invoke();
        public void Release() => _release.Invoke();

        public class Builder
        {
            private readonly MockMethod _wait = new MockMethod("MockSemaphoreSlimBookEnd#Wait");
            private readonly MockMethod _waitSync = new MockMethod("MockSemaphoreSlimBookEnd#WaitSync");
            private readonly MockMethod _release = new MockMethod("MockSemaphoreSlimBookEnd#Release");

            public MockSemaphoreSlimBookEnd Build()
            {
                return new MockSemaphoreSlimBookEnd
                {
                    _wait = _wait,
                    _waitSync = _waitSync,
                    _release = _release
                };
            }

            public Builder Wait()
            {
                _wait.UpdateInvocation();
                return this;
            }

            public Builder Wait(params Action[] actions)
            {
                _wait.UpdateInvocation(actions);
                return this;
            }

            public Builder WaitSync()
            {
                _waitSync.UpdateInvocation();
                return this;
            }

            public Builder WaitSync(params Action[] actions)
            {
                _waitSync.UpdateInvocation(actions);
                return this;
            }

            public Builder Release()
            {
                _release.UpdateInvocation();
                return this;
            }

            public Builder Release(params Action[] actions)
            {
                _release.UpdateInvocation(actions);
                return this;
            }
        }

        public void AssertWaitInvoked() => _wait.AssertInvoked();
        public void AssertWaitSyncInvoked() => _waitSync.AssertInvoked();
        public void AssertReleaseInvoked() => _release.AssertInvoked();
    }
}