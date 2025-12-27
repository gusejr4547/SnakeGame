using UnityEngine;

public class Food : MonoBehaviour
{
    // map의 충돌 범위 설정
    [SerializeField] private BoxCollider2D mapCollider2D;

    private void Awake()
    {
        SetupRandomizePosition();
    }

    private void SetupRandomizePosition()
    {
        Bounds bounds = mapCollider2D.bounds;

        int x = Random.Range((int)bounds.min.x, (int)bounds.max.x + 1);
        int y = Random.Range((int)bounds.min.y, (int)bounds.max.y + 1);

        // Food의 위치를 그리드에 맞게 조정
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SetupRandomizePosition();
    }
}
