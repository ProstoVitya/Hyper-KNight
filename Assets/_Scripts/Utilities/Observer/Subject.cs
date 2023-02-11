using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
        }

        public void RemoveObserver(IObserver observer)
        {
            
        }

        protected void NotifyObservers()
        {
            _observers.ForEach(o => o.OnNotyfy());
        }
    }   
}
