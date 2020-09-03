using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdManager : MonoBehaviour
{
    [Header("Necessary")]
    [SerializeField] private SquirrelController squirrel;
    [SerializeField] private Transform nutsParent;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform directionPoint;

    [Header("System")]
    [SerializeField] private Vector2 nutsSpawn;
    [SerializeField] private float endDistance;

    private GameObject[] nutsPattern;

    void Awake()
    {
        nutsPattern = Resources.LoadAll<GameObject>("ThirdPhase");
    }

    void OnEnable()
    {
        Launch();
    }

    void OnDisable()
    {
        for (int i = 0; i < nutsParent.childCount; i++)
        {
            Destroy(nutsParent.GetChild(i).gameObject);
        }
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 squirrelPos = squirrel.GetPosition();
        if (squirrelPos.x > endPoint.position.x)
        {
            // Next step
            Debug.Log("Won");
        }
    }

    public void Launch()
    {
        squirrel.SetPosition(startPoint.position);
        squirrel.SetDirection(directionPoint.position - startPoint.position);
        squirrel.Fly();
        if(endDistance > 0)
            endPoint.position = new Vector2(endDistance, endPoint.position.y);
        StartCoroutine("SpawnNuts");
    }

    private void SpawnNutPattern()
    {
        int index = Random.Range(0, nutsPattern.Length);
        GameObject nuts = Instantiate(nutsPattern[index], nutsParent);
        float camWidth = 2f * Camera.main.orthographicSize * Camera.main.aspect;
        Vector2 deltaPosition = squirrel.GetFlyingMovement() * (camWidth / 2f);
        nuts.transform.position = new Vector2(squirrel.GetPosition().x + deltaPosition.x, squirrel.GetPosition().y + deltaPosition.y);
    }

    IEnumerator SpawnNuts()
    {
        while(GameManager.instance.phase == GameManager.Phase.Third)
        {
            yield return new WaitForSeconds(Random.Range(nutsSpawn.x, nutsSpawn.y));
            SpawnNutPattern();
            Debug.Log("Nuuuuuuts");
        }
    }
}
