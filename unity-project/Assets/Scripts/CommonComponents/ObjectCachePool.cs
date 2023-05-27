using System;
using System.Collections.Generic;
using System.Linq;
using CommonComponents.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace CommonComponents
{
	public interface IObjectCachePool
	{
		PooledObject PullObject(bool activateObject = true);
		void ReturnToPool(PooledObject obj);
	}

	[Serializable]
	public class ObjectCachePool<T> : IObjectCachePool where T: PooledObject
	{
		private readonly T _obj;
		private readonly List<T> _pool;
		public int MaxNumber { get; set; }

		private int _currentActiveCount = 0;

		public ObjectCachePool(T obj, int maxNumber)
		{
			_obj = obj;
			MaxNumber = maxNumber;
			_pool = new List<T>(maxNumber);
			Init();
		}

		public void Init()
		{
			T item;
			while (_pool.Count < MaxNumber)
			{
				item = MonoBehaviour.Instantiate(_obj);
				item.SetPool(this);
				item.gameObject.SetActive(false);
				_pool.Add(item);
			}
		}

		public void Destroy()
		{
			foreach (var pooledObject in _pool)
			{
				if (!pooledObject.IsDestroyed())
				{
					pooledObject.gameObject.SetActive(false);
					MonoBehaviour.Destroy(pooledObject.gameObject, 0.1f);
				}
			}
			_pool.Clear();
		}


		public T PullObject(bool activateObject = true)
		{
			T found = null;
			if (_currentActiveCount < MaxNumber)
			{
				found = _pool.FirstOrDefault(t => !t.gameObject.activeInHierarchy);
				if (found != null)
				{
					_currentActiveCount++;
					found.gameObject.SetActive(activateObject);
					return found;
				}
			}

			MaxNumber += (MaxNumber / 4);
			Init();
			return PullObject(activateObject);
		}

		public void ReturnToPool(T obj)
		{
			if (obj.gameObject.activeInHierarchy)
			{
				_currentActiveCount--;
				obj.gameObject.SetActive(false);
			}
		}

		PooledObject IObjectCachePool.PullObject(bool activateObject) => PullObject(activateObject);

		void IObjectCachePool.ReturnToPool(PooledObject obj) => ReturnToPool((T)obj);
	}
}
