using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnakeGameNS
{
    public class SnakeAltMove : MonoBehaviour
    {
        [SerializeField] private ScoreUI ui;
        private int _score;

        public GameObject[,] gridArray = null;
        private int currentIndexX;
        private int currentIndexY;
        private int targetIndexX;
        private int targetIndexY;

        private Vector2 _direction = Vector2.up;
        private LList<Transform> _bodySegments;
        [SerializeField] private Transform BodyPrefab;
        private Vector3 previousPos;

        private float passedTime;
        [SerializeField] private float timeBetweenMovements = 0.1f;

        private void Start()
        {
            GetStartPosition();
            _bodySegments = new LList<Transform>();
            _bodySegments.Add(transform);
            _score = 0;
        }

        public void GetGridArray(GameObject[,] gridArray)
        {
            this.gridArray = gridArray;
        }

        public void GetStartPosition()
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    if (transform.position.x == gridArray[x, y].transform.position.x && transform.position.y == gridArray[x, y].transform.position.y)
                    {
                        currentIndexX = x;
                        currentIndexY = y;
                    }
                }
            }
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
            targetIndexX = currentIndexX + (int)_direction.x;
            targetIndexY = currentIndexY + (int)_direction.y;

            if (targetIndexX < 0 || targetIndexX >= gridArray.GetLength(0) || targetIndexY < 0 || targetIndexY >= gridArray.GetLength(1))
            {
                targetIndexX = currentIndexX;
                targetIndexY = currentIndexY;
                return;
            }

            if (gridArray[targetIndexX, targetIndexY] != null)
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
                    currentIndexX = targetIndexX;
                    currentIndexY = targetIndexY;
                }
            }
        }

        private void GameOver()
        {
            SceneManager.LoadScene(0);
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
                AddPoints();
            }
            else if (collision.tag == "Obstacle")
            {
                if(_score > PlayerPrefs.GetInt("Highscore"))
                {
                    PlayerPrefs.SetInt("Highscore", _score);
                }

                GameOver();               
            }
        }

        public void AddPoints()
        {
            _score++;
            ui.SetScoreText(_score);
        }
    }
}
