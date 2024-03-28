using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class EventLinkedList<T>: IEnumerable<T>
    {
        private LinkedList<T> _toAdd = new LinkedList<T>();
        
        // 
        public delegate void ElementHandler(T x);

        public delegate void UpdateHandler();
        
        public event ElementHandler onAddToFirst;
        public event ElementHandler onAddToLast;
        public event UpdateHandler onListUpdated;
        public event UpdateHandler onRemoveFirst;
        public event UpdateHandler onRemoveLast;
        
        public void AddLast(T x)
        {
            _toAdd.AddLast(x);
            onAddToLast?.Invoke(x);
            onListUpdated?.Invoke();
        }

        public void RemoveLast()
        {
            _toAdd.RemoveLast();
            onRemoveLast?.Invoke();
            onListUpdated?.Invoke();
        }

        public void AddFirst(T x)
        {
            _toAdd.AddFirst(x);
            onAddToFirst?.Invoke(x);
            onListUpdated?.Invoke();
        }

        public void RemoveFirst()
        {
            _toAdd.RemoveFirst();
            onRemoveFirst?.Invoke();
            onListUpdated?.Invoke();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _toAdd.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _toAdd.GetEnumerator();
        }
    }
}