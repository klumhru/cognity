using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.Events;

namespace Cognity {
  public class AWSReactiveBehaviour<T> : MonoBehaviour {
    private ConcurrentQueue<T> _queue;
    private T _next;
    public UnityEvent<T> QueuedEvents;

    public virtual void Awake() {
      _queue = new ConcurrentQueue<T>();
    }

    public virtual void Update() {
      while (_queue.TryDequeue(out _next)) {
        QueuedEvents?.Invoke(_next);
      }
    }

    protected void EnqueueMessage(T message) {
      _queue.Enqueue(message);
    }
  }
}
