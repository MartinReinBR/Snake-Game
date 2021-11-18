using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnakeGameNS
{
    public class GridTile : MonoBehaviour
    {
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _offsetColor;
        [SerializeField] private SpriteRenderer _renderer;

        public void InitializeTile(bool isOffset)
        {
            _renderer.color = isOffset ? _offsetColor : _baseColor;
        }

        public int x = 0;
        public int y = 0;
    }
}
