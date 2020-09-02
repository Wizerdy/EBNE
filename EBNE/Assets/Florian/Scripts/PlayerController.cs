using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int side;
    private bool key;
    [Tooltip("La rapidité du joueur entre les changements de voie")]
    public float sideMoveSpeed;

    private bool canChangeSide;
    private bool boolSide;

    [Tooltip("La distance parcouru lorsque le joueur swipe left")]
    public Vector2 movingLeft;
    [Tooltip("La distance parcouru lorsque le joueur swipe right")]
    public Vector2 movingRight;
    private Vector2 startPos;
    private Vector2 endPos;

    private Animator closeAnim;
    private CloseEnemy _closeEnemy;

    void Start()
    {
        _closeEnemy = FindObjectOfType<CloseEnemy>();
        closeAnim = FindObjectOfType<Animator>();

        side = 1;
    }

    void Update()
    {
        Swipe();
        ChangeSide();
    }

    void Swipe()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startPos = Input.mousePosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            endPos = Input.mousePosition;

            var finalDir = endPos.x - startPos.x;
            //Debug.Log(finalDir);

            if (finalDir < 0)
            {
                if(side != 0)
                {
                    side -= 1;
                    canChangeSide = true;
                }
            }
            else
            {
                if(side != 2)
                {
                    side += 1;
                    canChangeSide = true;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (side != 0)
            {
                side -= 1;
                canChangeSide = true;
                key = true;
            }
           
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (side != 2)
            {
                side += 1;
                canChangeSide = true;
                key = true;
            }
        }
    }

    void ChangeSide()
    {
        if (canChangeSide)
        {
            if (side == 0)
            {
                if (endPos.x - startPos.x < 0 || key)
                {
                    transform.position = Vector3.MoveTowards(transform.position, movingLeft, sideMoveSpeed * Time.deltaTime);
                }

                if (transform.position.x == movingLeft.x)
                {
                    canChangeSide = false;
                    key = false;
                }
            }

            if (side == 1)
            {

                transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), sideMoveSpeed * Time.deltaTime);

                if (transform.position.x == 0)
                {
                    canChangeSide = false;
                    key = false;
                }

            }

            if (side == 2)
            {
                if (endPos.x - startPos.x > 0 || key)
                {
                    transform.position = Vector3.MoveTowards(transform.position, movingRight, sideMoveSpeed * Time.deltaTime);
                }

                if (transform.position.x == movingRight.x)
                {
                    canChangeSide = false;
                    key = false;
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Close"))
        {
            //Debug.Log("close");
            closeAnim.SetTrigger("close");
            _closeEnemy.boolMT();
        }
    }
}
