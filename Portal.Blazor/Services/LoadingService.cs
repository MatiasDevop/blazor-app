using System;
using System.Reactive.Subjects;

namespace Portal.Blazor.Services
{
    public class LoadingService
    {
        private readonly BehaviorSubject<int> _locks = new(0);

        public IObservable<int> Locks => _locks;

        public void Show() => _locks.OnNext(_locks.Value + 1);

        public void Hide() => _locks.OnNext(_locks.Value - 1);

        public void Reset() => _locks.OnNext(0);
    }
}
