using BlockRooms.Model.Units.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlockRooms.Model.Units.Extensions
{
    public class Extensions
    {
        public event Action<IExtension> Added;

        private List<IExtension> _extensions;

        public Extensions()
        {
            _extensions = new List<IExtension>();
        }

        public bool Has<T>() where T : IExtension
        {
            return _extensions.FirstOrDefault(e => e is T) != null;
        }

        public bool Has<T>(out T result) where T : class, IExtension
        {
            result = _extensions.FirstOrDefault(e => e is T) as T;
            return result != null;
        }

        public T Get<T>() where T : class, IExtension
        {
            return (T)_extensions.FirstOrDefault(e => e is T);
        }

        public void Add(IExtension extension)
        {
            _extensions.Add(extension);
            Added?.Invoke(extension);
        }

        public void Remove<T>() where T : class, IExtension
        {
            if (Has(out T item))
                _extensions.Remove(item);
            else
                Debug.LogWarning("Такого расширения нет");
        }
    }
}
