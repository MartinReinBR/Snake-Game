using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGameNS
{
    public class GridBehavior : MonoBehaviour
    {
        public int rows = 10;
        public int columns = 10;
        public int scale = 1;
        public GameObject gridPrefab;
        public Vector2 leftBottomLocation = new Vector2(0, 0);


        private void Awake()
        {
            if (gridPrefab)
            {
                GenerateGrid();
            }
            else print("Missing gridPrefab, please dab");
        }

        void GenerateGrid()
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    GameObject obj = Instantiate(gridPrefab, new Vector2(leftBottomLocation.x + scale * x, leftBottomLocation.y + scale * y), Quaternion.identity);
                    obj.transform.SetParent(gameObject.transform);
                    obj.GetComponent<SnakeGrid>().x = x;
                    obj.GetComponent<SnakeGrid>().y = y;
                }
            }
        }

    }
}
