using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cognity {

  // Simple extension of the MonoBehaviour class that implements IObservable
  // Lifted straight from https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern
  // Uses ConcurrentQueue to contain the off-ui-thread queue of events that are picked up
  // on Update to push UI changes
  public class ObservableBehaviour<T> : MonoBehaviour, IObservable<T> {
    private List<IObserver<T>> observers;
    private ConcurrentQueue<T> _queue;
    private T _next;
    // public UnityEvent<T> QueuedEvents;

    public virtual void Awake() {
      observers = new List<IObserver<T>>();
      _queue = new ConcurrentQueue<T>();
    }

    public virtual void Update() {
      while (_queue.TryDequeue(out _next)) {
        foreach (var observer in observers) {
          observer.OnNext(_next);
        }
      }
    }

    protected void EnqueueMessage(T message) {
      _queue.Enqueue(message);
    }

    public IDisposable Subscribe(IObserver<T> observer) {
      observers.Add(observer);
      return new Unsubscriber<T>(observers, observer);
    }
  }

  internal class Unsubscriber<T> : IDisposable {
    private List<IObserver<T>> _observers;
    private IObserver<T> _observer;
    internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer) {
      _observers = observers;
      _observer = observer;
    }
    public void Dispose() {
      if (_observers.Contains(_observer)) _observers.Remove(_observer);
    }
  }
}
