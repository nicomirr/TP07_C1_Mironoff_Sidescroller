using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Game.Core;

namespace Game.Throwables
{
    public class ThrowableFactory
    {
        private readonly Transform _parent;

        private readonly ThrowableFactoryDataSo _data;

        private readonly Dictionary<ThrowableType, Throwable> _throwablesPrefabs = new();

        public ThrowableFactory(ThrowableFactoryDataSo data, Transform parent)
        {
            _data = data;

            foreach(ThrowablePrefabDataSo prefab in data.ThrowablePrefabs)
            {
                // Warning: El return de abajo sale del constructor antes de asignar _parent y deja sin registrar los prefabs restantes.
                // Usá continue para saltear sólo el prefab inválido y asigná _parent al principio del constructor.
                if(!prefab.ThrowablePrefab.TryGetComponent<Throwable>(out Throwable throwable))
                {
                    Debug.LogError("Error. Los prefabs para el ThrowableFactory deberian todos ser de tipo Throwable.");
                    return;
                }              

                _throwablesPrefabs.Add(prefab.ThrowableType, throwable);
            }

            _parent = parent;
        }

        public List<Throwable> CreatePool(ThrowableType throwableType)
        {
            List<Throwable> pool = new List<Throwable>();

            for (int i = 0; i < _data.PoolSize; i++)
            {
                Throwable throwable = Object.Instantiate(_throwablesPrefabs[throwableType], _parent);
                throwable.gameObject.SetActive(false);

                pool.Add(throwable);
            }

            return pool;
        }
    }

}

