using UnityEngine;

namespace Task2
{
    public class LineScript : MonoBehaviour
    {
        #region Private Serialize Field
        [SerializeField] private Transform _balloonTransform;
        #endregion

        #region Private Field
        private LineRenderer _lineRenderer;
        private Transform _ropeEndTransform;
        #endregion

        #region Start
        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _ropeEndTransform = GameObject.Find("Cube").transform;
        }
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