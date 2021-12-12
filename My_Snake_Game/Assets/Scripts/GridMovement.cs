using System.Collections;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public GameObject[,] gridArray = null;

    private bool isMoving;
    [SerializeField]private int currentIndexX;
    [SerializeField]private int currentIndexY;
    [SerializeField]private int targetIndexX;
    [SerializeField]private int targetIndexY;

    private Vector3 origPos;
    private Vector3 targetPos;
    private float timeToMove = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        GetStartPosition();
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            targetIndexY = currentIndexY + 1;
            targetIndexX = currentIndexX;
            Move(Vector3.up);
        }

        else if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            targetIndexY = currentIndexY - 1;
            targetIndexX = currentIndexX;
            Move(Vector3.down);
        }

        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            targetIndexX = currentIndexX + -1;
            targetIndexY = currentIndexY;
            Move(Vector3.left);
        }

        else if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            targetIndexX = currentIndexX + 1;
            targetIndexY = currentIndexY;
            Move(Vector3.right);
        }
    }

    public void Move(Vector3 direction)
    {
        if (targetIndexX < 0 || targetIndexX >= gridArray.GetLength(0) || targetIndexY < 0 || targetIndexY >= gridArray.GetLength(1))
        {
            targetIndexX = currentIndexX;
            targetIndexY = currentIndexY;
            return;
        }         
        
        if(gridArray[targetIndexX, targetIndexY] != null)
        {
            Vector3 moveDirection = direction;

            StartCoroutine(MovePlayer(moveDirection));
            currentIndexX = targetIndexX;
            currentIndexY = targetIndexY;
        }
        
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    public void GetGridArray(GameObject[,] gridArray)
    {
        this.gridArray = gridArray;
    }
}
