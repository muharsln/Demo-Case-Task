using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task2
{
    public class BaloonSpawnManager : MonoBehaviour
    {
        #region Private Serialize Field
        [Header("Object Pooling")]
        [SerializeField] private GameObject _poolObject;
        [SerializeField] private byte _poolAmount;

        [Header("Spawn Referance")]
        [SerializeField] private Transform _spawnPoint;
        #endregion

        #region Private Field
        // Object Pool list
        private List<GameObject> _pool;
        #endregion

        #region Start
        private void Start()
        {
            _pool = new List<GameObject>();

            for (int i = 0; i < _poolAmount; i++)
            {
                _pool.Add(Instantiate(_poolObject, _spawnPoint.position, Quaternion.identity, transform));
            }

            StartCoroutine(BalloonSetActive());
        }
        #endregion

        #region Coroutine
        IEnumerator BalloonSetActive()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].activeInHierarchy)
                {
                    _pool[i].SetActive(true);
                    yield return new WaitForSeconds(2f);
                }
            }
        }
        #endregion
    }
}