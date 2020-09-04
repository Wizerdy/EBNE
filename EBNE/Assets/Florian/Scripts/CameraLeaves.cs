using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeaves : MonoBehaviour
{

    public GameObject leave;
    public GameObject go;
    public float gausLeaveSpawn;
    private float saveGausLeaveSpawn;

    public float leaveFallSpeed;

    public Transform[] spawnPoints;

    public float xAxeRandomNegative;
    public float xAxeRandomPositive;

    private bool move;
    private bool newCorou;


    void Start()
    {
        newCorou = true;
        saveGausLeaveSpawn = gausLeaveSpawn;
    }

    IEnumerator Spawn() {
        gausLeaveSpawn = saveGausLeaveSpawn;
        gausLeaveSpawn += Random.Range(-1, 1);
        yield return new WaitForSeconds(gausLeaveSpawn);
        var rr = Random.Range(0, 2);
        Vector2 vector = new Vector2(spawnPoints[rr].transform.position.x , spawnPoints[rr].transform.position.y);
        vector.x += Random.Range(xAxeRandomNegative, xAxeRandomPositive);
        go = Instantiate(leave, vector, Quaternion.identity);
        move = true;
        go.transform.rotation = new Quaternion(0, 0, Random.Range(0, 180), 0);
    }

    void Update()
    {
        if(move == true)
        {
            go.transform.position = Vector2.MoveTowards(go.transform.position, new Vector2(go.transform.position.x, go.transform.position.y + 1), leaveFallSpeed * Time.deltaTime);


            if(go.transform.position.y <= -8)
            {
                go.SetActive(false);
                move = false;
                newCorou = true;
            }
        }

        if(newCorou)
        {
            StartCoroutine(Spawn());
            newCorou = false;
        }
       
    }
}
