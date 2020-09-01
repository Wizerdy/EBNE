using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public float fallingSpeed;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -5), fallingSpeed * Time.deltaTime);
    }
}
