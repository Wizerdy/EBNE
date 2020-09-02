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

    [Tooltip("La distance parcouru lorsque le joueur passe de la voie 2 à la voie 1 (lorsque l'arbre s'est décale vers la gauche, la nouvelle voie créée est la voie 1)")]
    public Vector2 movingLeftLeft;
    [Tooltip("La distance parcouru lorsque le joueur passe de la voie 4 à la voie 5 (lorsque l'arbre s'est décale vers la droite, la nouvelle voie créée est la voie 5)")]
    public Vector2 movingRightRight;

    private Vector2 startPos;
    private Vector2 endPos;

    private Animator closeAnim;
    private CloseEnemy _closeEnemy;

    private ScoreManager _scoreManager;

    public bool leftRoad = false;
    public bool rightRoad = false;

    void Start()
    {
        leftRoad = false; rightRoad = false;
        _scoreManager = FindObjectOfType<ScoreManager>();
        _closeEnemy = FindObjectOfType<CloseEnemy>();
        closeAnim = GetComponent<Animator>();

        side = 1;
    }

    void Update()
    {
        if(leftRoad == true)
        {
            SwipeLeft();
            //Debug.Log("left");
        }
        else if(rightRoad == true)
        {
            SwipeRight();
            //Debug.Log("right");
        }
        else if(!leftRoad && !rightRoad)
        {
            Swipe();
        }

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
            if(side != 0)
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

    void SwipeLeft()
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
                if (side != -1)
                {
                    side -= 1;
                    canChangeSide = true;
                }
            }
            else 
            {
                if(side != 1)
                {
                    side += 1;
                    canChangeSide = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (side != -1)
            {
                side -= 1;
                canChangeSide = true;
                key = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (side != 1)
            {
                side += 1;
                canChangeSide = true;
                key = true;

            }

        }
        
    }

    void SwipeRight()
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
                    if (side != 1)
                    {
                        side -= 1;
                        canChangeSide = true;
                    }
                }
                else
                {
                    if (side != 3)
                    {
                        side += 1;
                        canChangeSide = true;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (side != 1)
                {
                    side -= 1;
                    canChangeSide = true;
                    key = true;
                }

            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (side != 3)
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
            if (side == -1)
            {
                if (endPos.x - startPos.x < 0 || key)
                {
                    transform.position = Vector3.MoveTowards(transform.position, movingLeftLeft, sideMoveSpeed * Time.deltaTime);
                }

                if (transform.position.x == movingLeftLeft.x)
                {
                    canChangeSide = false;
                    key = false;
                }
            }

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

            if(side == 3)
            {
                if (endPos.x - startPos.x > 0 || key)
                {
                    transform.position = Vector3.MoveTowards(transform.position, movingRightRight, sideMoveSpeed * Time.deltaTime);
                }

                if (transform.position.x == movingRightRight.x)
                {
                    canChangeSide = false;
                    key = false;
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FallDetection"))
        {
            closeAnim.SetTrigger("death");
            Debug.Log(closeAnim);
            Debug.Log("death by fall");
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }

        if (collision.gameObject.CompareTag("Close"))
        {
            //Debug.Log("close");
//          closeAnim.SetTrigger("close");
            _closeEnemy.boolMT();
            FindObjectOfType<CameraShake>().Shake();
        }

        if (collision.gameObject.CompareTag("Gland"))
        {
            //Debug.Log("gland++");
            _scoreManager.GotGland();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("LeftPart"))
        {
            if(rightRoad == true)
            {
                rightRoad = false;
                leftRoad = false;
            }
            else
            {
                leftRoad = true;
            }
        }

        if (collision.gameObject.CompareTag("MidPart"))
        {
            leftRoad = false;
            rightRoad = false;
        }

        if (collision.gameObject.CompareTag("RightPart"))
        {
            if (leftRoad == true)
            {
                rightRoad = false;
                leftRoad = false;
            }
            else
            {
                rightRoad = true;
            }
        }
    }
}
