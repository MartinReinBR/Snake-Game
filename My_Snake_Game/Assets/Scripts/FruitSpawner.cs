using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGameNS
{
    public class FruitSpawner : MonoBehaviour
    {
        private GameObject[,] GridArray = null;
        [SerializeField]private GameObject fruitPrefab;
        private int fruitSpawnIndexX;
        private int fruitSpawnIndexY;
        private bool isGridOccupied = true;

        private void Start()
        {
            if(GridArray != null)
                SpawnFruit();
        }

        public void GetGridArray( GameObject [,] gridArray)
        {
            GridArray = gridArray;
        }

        private Vector3 RandomPosition()
        {
            isGridOccupied = true;
            GameObject pointToSpawn = null;
            while (isGridOccupied)
            {
                fruitSpawnIndexX = Random.Range(1, GridArray.GetLength(0) - 1);
                fruitSpawnIndexY = Random.Range(1, GridArray.GetLength(1) - 1);

                pointToSpawn = GridArray[fruitSpawnIndexX, fruitSpawnIndexY];
                if (!pointToSpawn.GetComponent<GridTile>().isOccupied)
                    isGridOccupied = false;
            }

            return new Vector3(Mathf.Round(pointToSpawn.transform.position.x), Mathf.Round(pointToSpawn.transform.position.y), 0f);
        }

        public void SpawnFruit()
        {
            Vector3 spawnPosition = RandomPosition();
            Instantiate(fruitPrefab, spawnPosition, transform.rotation);
        }
    }
}
