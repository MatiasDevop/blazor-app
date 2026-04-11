using System.Collections.Generic;
using System.Reactive.Subjects;

namespace Portal.Blazor.Extensions;

public static class BehaviorSubjectExtensions
{
    public static void AddRange<T>(this BehaviorSubject<List<T>> subject, IEnumerable<T> records)
    {
        subject.Value.AddRange(records);
        subject.OnNext(subject.Value);
    }

    public static void Remove<T>(this BehaviorSubject<List<T>> subject, T record)
    {
        subject.Value.Remove(record);
        subject.OnNext(subject.Value);
    }
}
