using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task1
{
    public class DrawController : MonoBehaviour
    {
        #region Singleton
        public static DrawController Instance { get; set; }
        #endregion

        #region Observer
        public event Action meshCombine;
        #endregion

        #region Private Serialize Field
        [Header("Base Referance")]
        [SerializeField] private Camera _mainCam;

        [Header("Object Referance")]
        [SerializeField] private GameObject _linePrefab;
        [SerializeField] private GameObject _instantiateCube;

        [Header("Spawn Referance")]
        [SerializeField] private Transform _parentObject;

        [Header("Mesh Referance")]
        [SerializeField] private MeshFilter _newMesh;
        #endregion

        #region Private Field
        private Coroutine _drawingCoroutine;
        private List<Vector3> _meshPositions;
        private LineRenderer _line;
        #endregion

        #region Awake
        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            _meshPositions = new List<Vector3>();
        }
        #endregion

        #region Update
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                StartLine();

            if (Input.GetMouseButtonUp(0))
                FinishLine();
        }
        #endregion

        #region Private Methods
        private void StartLine()
        {
            if (_drawingCoroutine != null)
            {
                StopCoroutine(_drawingCoroutine);
            }

            _drawingCoroutine = StartCoroutine(DrawLine());
        }

        private void FinishLine()
        {
            StopCoroutine(_drawingCoroutine);
            AddMeshPosition();
            CreateCube();
            Destroy(_line.gameObject);
        }

        private void AddMeshPosition()
        {
            for (int i = 0; i < _line.positionCount; i+=2 )
            {
                _meshPositions.Add(_line.GetPosition(i));
            }
        }

        private void CreateCube()
        {
            for (int i = 0; i < _meshPositions.Count; i++)
            {
                Instantiate(_instantiateCube, _meshPositions[i], Quaternion.identity, _parentObject);
            }

            meshCombine?.Invoke();
        }
        #endregion

        #region Coroutine
        private IEnumerator DrawLine()
        {
            GameObject newLineObject = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity);
            _line = newLineObject.GetComponent<LineRenderer>();
            _line.positionCount = 0;

            while (true)
            {
                Vector3 position = _mainCam.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;
                _line.positionCount++;
                _line.SetPosition(_line.positionCount - 1, position);
                yield return null;
            }
        }
        #endregion
    }
}