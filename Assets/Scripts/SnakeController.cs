using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour
{
    private Vector2Int moveDirection = Vector2Int.right;
    // SerializeField makes private fields visible in the Unity Inspector
    [SerializeField] private float moveInterval = 0.2f; // Move every 0.2 seconds

    // Use this for initialization
    void Start()
    {
        Debug.Log("SnakeController has started.");
        StartCoroutine(MoveLoop());
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
    }

    void MoveSnake()
    {
        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0f);
    }


    private IEnumerator MoveLoop()
    {
        var wait = new WaitForSeconds(moveInterval);
        while(true)
        {
            MoveSnake();
            yield return new WaitForSeconds(moveInterval);
        }
    }

}
