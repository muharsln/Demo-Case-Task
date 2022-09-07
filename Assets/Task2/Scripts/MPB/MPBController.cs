using UnityEngine;
using Random = UnityEngine.Random;

namespace Task2
{
    public class MPBController : MonoBehaviour
    {
        #region Private Serialize Field
        [SerializeField] private ColorData _colorData;
        #endregion

        #region Private Field
        private MeshRenderer _renderer;
        private MaterialPropertyBlock _mPB;
        #endregion

        #region Awake
        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _mPB = new MaterialPropertyBlock();
            SetRendererMat();
        }
        #endregion

        #region Private Method
        private void SetRendererMat()
        {
            _mPB.SetColor("_Color", _colorData.Colors[Random.Range(0, 5)]);
            _renderer.SetPropertyBlock(_mPB);
        }
        #endregion
    }
}