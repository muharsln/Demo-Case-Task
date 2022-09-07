using System.Collections;
using UnityEngine;

namespace Task2
{
    public class BaloonController : MonoBehaviour
    {
        #region Private Serialize Field
        [SerializeField] private GameObject _balloon;
        #endregion

        #region Start
        private void Start() =>
            StartCoroutine(PosUp());
        #endregion

        #region Coroutine
        IEnumerator PosUp()
        {
            while (transform.position.y < 1.5f)
            {
                if (_balloon.transform.localScale != Vector3.one)
                {
                    _balloon.transform.localScale = Vector3.Lerp(_balloon.transform.localScale, Vector3.one, Time.deltaTime);
                }
                transform.position += Vector3.up * 1 * Time.deltaTime;
                yield return null;
            }
        }
        #endregion
    }
}