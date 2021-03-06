using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGameNS
{
    public class Fruit : MonoBehaviour
    {
        private GameObject spawner;

        private void Start()
        {
            spawner = GameObject.FindWithTag("Spawner");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                spawner.GetComponent<FruitSpawner>().SpawnFruit();
                Destroy(gameObject);
            }
        }
    }
}
