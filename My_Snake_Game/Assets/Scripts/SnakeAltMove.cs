using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnakeGameNS
{
    public class SnakeAltMove : MonoBehaviour
    {

        private Vector2 _direction = Vector2.up;
        private LList<Transform> _bodySegments;
        public Transform BodyPrefab;

        private Vector3 previousPos;

        float passedTime;
        public float timeBetweenMovements = 0.1f;

        private void Start()
        {
            _bodySegments = new LList<Transform>();
            _bodySegments.Add(transform);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
            {
                _direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
            {
                _direction = Vector2.down;
            }
            else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
            {
                _direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
            {
                _direction = Vector2.right;
            }

        }

        private void FixedUpdate()
        {
            passedTime += Time.deltaTime;
            if (timeBetweenMovements < passedTime)
            {
                previousPos = transform.position;
                passedTime = 0;
                // Move
                for (int i = _bodySegments.Count - 1; i > 0; i--)
                {
                    _bodySegments[i].position = _bodySegments[i - 1].position;
                }

                transform.position = new Vector3(transform.position.x + _direction.x, transform.position.y + _direction.y, 0f);
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        private void IncreaseSize()
        {
            Transform bodySegment = Instantiate(BodyPrefab, previousPos, Quaternion.identity);
            _bodySegments.Add(bodySegment);
            bodySegment.position = _bodySegments[_bodySegments.Count - 1].position;

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Fruit")
            {
                IncreaseSize();
            }
            else if (collision.tag == "Obstacle")
            {
                RestartGame();
            }
        }
    }
}
