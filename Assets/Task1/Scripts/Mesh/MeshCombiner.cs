using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task1
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class MeshCombiner : MonoBehaviour
    {
        private MeshFilter _meshFilter;

        private void Start()
        {
            _meshFilter = GetComponent<MeshFilter>();
            DrawController.Instance.meshCombine += CombineMesh;
        }
        private void CombineMesh()
        {
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            for (int i = 0; i < meshFilters.Length; i++)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false);
            }

            _meshFilter.mesh = new Mesh();
            _meshFilter.mesh.CombineMeshes(combine);
            transform.gameObject.SetActive(true);

            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}