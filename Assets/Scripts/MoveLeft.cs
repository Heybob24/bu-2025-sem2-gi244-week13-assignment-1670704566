using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    private ObstacleObjectPool pool;
    private Rigidbody rb;

    public int obstacleType;

    void Start()
    {
        pool = FindFirstObjectByType<ObstacleObjectPool>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // 🔥 ใช้ FixedUpdate แทน Update
    {
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;

        if (isGameOver)
        {
            return;
        }

        // 🔥 ใช้ physics movement
        rb.MovePosition(
            transform.position + Vector3.left * speed * Time.fixedDeltaTime
        );

        if (transform.position.x < -15)
        {
            pool.Release(gameObject, obstacleType);
        }
    }
}