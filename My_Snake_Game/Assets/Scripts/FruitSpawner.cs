using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public BoxCollider2D SpawnArea;
    public GameObject fruitPrefab;

    private void Start()
    {
        SpawnArea = GetComponent<BoxCollider2D>();
        SpawnFruit();
    }

    private Vector3 RandomPosition()
    {
        Bounds bounds = SpawnArea.bounds;

        float xPosition = Random.Range(bounds.min.x, bounds.max.x);
        float yPosition = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector3(Mathf.Round(xPosition), Mathf.Round(yPosition), 0f);
    }

    public void SpawnFruit()
    {
        Instantiate(fruitPrefab, RandomPosition(), transform.rotation);
    }
}
