using UnityEngine;

namespace SnakeGameNS
{
    public class GridTile : MonoBehaviour
    {
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _offsetColor;
        [SerializeField] private SpriteRenderer _renderer;

        public bool isOccupied = false;

        public void InitializeTile(bool isOffset)
        {
            _renderer.color = isOffset ? _offsetColor : _baseColor;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" || collision.tag == "Obstacle")
            {
                isOccupied = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player" || collision.tag == "Obstacle")
            {
                isOccupied = false;
            }
        }
    }
}
