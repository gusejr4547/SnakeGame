using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2Int moveDirection = Vector2Int.right;
    private float timer = 0f;
    private float moveInterval = 0.2f; // Move every 0.2 seconds

    // Use this for initialization
    void Start()
    {


        Debug.Log("SnakeController has started.");
    }

    // Update is called once per frame
    void Update()
    {
        // Snake movement logic would go here
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            moveDirection = Vector2Int.up;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)){
            moveDirection = Vector2Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            moveDirection = Vector2Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            moveDirection = Vector2Int.right;
        }

        timer += Time.deltaTime;
        if(timer >= moveInterval)
        {
            timer = 0f;
            MoveSnake();
        }
    }

    void MoveSnake()
    {
        Vector3 nextPos = transform.position;
        nextPos.x += moveDirection.x;
        nextPos.y += moveDirection.y;

        transform.position = nextPos;
    }


   private IEnumerator MoveLoop()
    {
        while(true)
        {
            transform.position += (Vector3) moveDirection;
            yield return new WaitForSeconds(moveInterval);
        }
    }

}
