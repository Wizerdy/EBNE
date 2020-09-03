using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemy : MonoBehaviour
{

    private bool canMT;
    private bool closeMT;
    private bool timer;

    public float moveSpeed;
    [Tooltip("Temps avant que le joueur reprenne de l'avance sur le feu lorsqu'il à tribuché juste avant")]
    public float timeBfrReset;
    private float saveTBR;

    [Tooltip("La position du feu lorsque le joueur aura tribuché")]
    public Vector2 endPos;
    private Vector2 originPos;

    private void Start()
    {
        saveTBR = timeBfrReset;
        originPos = transform.position;
    }

    public void boolMT()
    {
        if(timeBfrReset != saveTBR)
        {
            FindObjectOfType<PlayerController>().Death();
        }

        canMT = true;
        closeMT = true;
        timer = true;
    }

    void Update()
    {
        if (closeMT)
        {
            if (canMT)
            {
                transform.position = Vector2.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, originPos, moveSpeed / 2 * Time.deltaTime);

                Vector2 theVector = new Vector2(transform.position.x, transform.position.y);
                if (theVector == originPos) closeMT = false;
            }
        }
        

        if (timer)
        {
            timeBfrReset -= Time.deltaTime;
            if(timeBfrReset <= 0)
            {
                canMT = false;
                timeBfrReset = saveTBR;
                timer = false;
            }
        }

    }

}
