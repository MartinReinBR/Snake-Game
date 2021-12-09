using UnityEngine;

namespace SnakeGameNS
{
    public class GridBehavior : MonoBehaviour
    {
        [SerializeField]private GameObject fruitSpawner;
        [SerializeField] private GameObject player;

        [SerializeField] private int rows = 10;
        [SerializeField] private int columns = 10;
        [SerializeField] private int scale = 1;
        [SerializeField] private GameObject gridPrefab;
        [SerializeField] private GameObject gridWallPrefab;
        [SerializeField] private Vector2 leftBottomLocation = new Vector2(0, 0);
        private GameObject[,] gridArray;


        private void Awake()
        {
            gridArray = new GameObject[columns, rows];
            if (gridPrefab)
            {
                GenerateGrid();
                fruitSpawner.GetComponent<FruitSpawner>().GetGridArray(gridArray);
                player.GetComponent<SnakeAltMove>().GetGridArray(gridArray);
            }
        }

        void GenerateGrid()
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    GameObject gridToInstansiate = gridPrefab;
                    if(x == 0 || x == columns - 1  || y == 0 || y == rows - 1)
                        gridToInstansiate = gridWallPrefab;

                    GameObject obj = Instantiate(gridToInstansiate, new Vector2(leftBottomLocation.x + scale * x, leftBottomLocation.y + scale * y), Quaternion.identity);
                    obj.transform.SetParent(gameObject.transform);

                    var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                    obj.GetComponent<GridTile>().InitializeTile(isOffset);

                    gridArray[x, y] = obj;
                }
            }
        }
    }
}
