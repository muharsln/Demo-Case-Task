using UnityEngine;

namespace Task2
{
    [CreateAssetMenu(menuName = "ColorData")]
    public class ColorData : ScriptableObject
    {
        [SerializeField] private Color[] _colors = new Color[5];

        public Color[] Colors => _colors;
    }
}