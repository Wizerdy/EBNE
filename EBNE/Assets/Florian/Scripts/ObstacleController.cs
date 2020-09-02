using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [Tooltip("Vitesse de tombé de l'obstacle (le joueur n'avance pas, ce sont les obstacles qui bougent)")]
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
