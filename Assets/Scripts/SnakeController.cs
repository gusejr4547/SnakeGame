using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour
{
    private Vector2Int moveDirection = Vector2Int.right;
    // 실제 Snake 이동 방향은 안변했는데 같은 축 방향 변경이 가능한 경우 방지
    // 오른쪽 가다가 상,좌 방향키 빠르게 누르면 왼쪽으로 가능경우 있음.
    private Vector2Int lastInputDirection = Vector2Int.right;

    // SerializeField makes private fields visible in the Unity Inspector
    [SerializeField] private float moveInterval = 0.1f; // Move every 0.1 seconds

    // 몸통
    [SerializeField] private Transform segmentPrefab;
    [SerializeField] private int snakeLength = 4; // 머리 포함 길이
    private List<Transform> segments = new List<Transform>(); // 몸통 조각 관리


    // Use this for initialization
    void Start()
    {
        Debug.Log("SnakeController has started.");
        Setup();
        StartCoroutine(MoveLoop());
    }

    // Update is called once per frame
    void Update()
    {
        // Snake movement logic would go here
        // x축 이동하면 y축만 방향 전환 가능
        if (moveDirection.x != 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                lastInputDirection = Vector2Int.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                lastInputDirection = Vector2Int.down;
            }
        }
        else if (moveDirection.y != 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                lastInputDirection = Vector2Int.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                lastInputDirection = Vector2Int.right;
            }
        }
    }

    void MoveSnake()
    {
        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0f);
    }

    private IEnumerator MoveLoop()
    {
        var wait = new WaitForSeconds(moveInterval);
        while (true)
        {
            MoveSegments();
            yield return wait;
        }
    }

    private void Setup()
    {
        // 초기 몸통 설정
        segments.Add(this.transform); // 머리 추가
        for (int i = 0; i < snakeLength - 1; i++)
        {
            AddSegment();
        }
    }

    private void AddSegment()
    {
        // 몸통 조각 추가
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    private void MoveSegments()
    {
        // 실제 이동 전에 마지막 입력방향 반영
        moveDirection = lastInputDirection;

        // 몸통 조각 이동
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        // 머리 이동
        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0f);
    }
}
