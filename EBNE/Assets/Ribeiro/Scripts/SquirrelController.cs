using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float speed;

    private Vector2 flyingDirection;
    private Rigidbody2D rb;

    private Coroutine lerpVel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Dive();
        } else if (Input.GetMouseButtonUp(0))
        {
            Fly();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Gland"))
        {
            Destroy(col.gameObject);
            GameManager.instance.scoreManager.GotGland();
        }
    }

    public void Fly()
    {
        //rb.velocity = flyingDirection * speed;
        if (lerpVel != null)
            StopCoroutine(lerpVel);
        lerpVel = StartCoroutine(LerpVelocity(flyingDirection * speed, 0.2f));
    }

    public void Dive()
    {
        //rb.velocity = Vector2.up * -speed;
        if (lerpVel != null)
            StopCoroutine(lerpVel);
        lerpVel = StartCoroutine(LerpVelocity(Vector2.down * speed, 0.2f));
    }

    public void SetPosition(Vector2 pos)
    {
        rb.position = pos;
    }

    public Vector2 GetPosition()
    {
        return rb.position;
    }

    public void SetDirection(Vector2 dir)
    {
        flyingDirection = dir.normalized;
    }

    public Vector2 GetFlyingMovement()
    {
        return flyingDirection * speed;
    }

    IEnumerator LerpVelocity(Vector2 wanted, float time)
    {
        Vector2 actual = rb.velocity;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(time / 10f);
            rb.velocity = Vector2.Lerp(actual, wanted, (float)i / 10f);
        }
    }
}
