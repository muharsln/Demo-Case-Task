using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task2
{
    public class LineScript : MonoBehaviour
    {
        #region Private Serialize Field
        [SerializeField] private Transform _balloonTransform, _ropeEndTransform;
        #endregion

        #region Private Field
        private LineRenderer _lineRenderer;
        #endregion

        #region Start
        private void Start() =>
            _lineRenderer = GetComponent<LineRenderer>();
        #endregion

        #region Update
        private void Update()
        {
            _lineRenderer.SetPosition(0, _balloonTransform.position);
            _lineRenderer.SetPosition(1, _ropeEndTransform.position);
        }
        #endregion
    }
}