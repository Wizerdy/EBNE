using UnityEngine;

public class GlandController : MonoBehaviour
{

    [Tooltip("L'élement 0 doit être la partie gauche du tronc, l'élément 1 la partie du milieu et l'élement 2 la partie de droite")]
    public GameObject[] spawnPoints;

    [Tooltip("Probabilité sur 100 (50 = 1 chance sur 2 puisque 50/100 = 2, qu'un gland spawn quelque part sur un tronc" +
        "-- Par défaut je l'ai mis à 1 chance sur 2")]
    public int probToSpawn;

    [Tooltip("La prefab du gland")]
    public GameObject gland;

    void Start()
    {
        if(probToSpawn == 0)
        {
            probToSpawn = 50;
        }

        var rr = Random.Range(0, 100 + 1);

        if(rr < probToSpawn)
        {
            var _rr = Random.Range(0, spawnPoints.Length);
            while(spawnPoints[_rr].transform.childCount != 0)
            {
                _rr = Random.Range(0, spawnPoints.Length);
                Debug.Log("spawn point plein");
            }
            Instantiate(gland, spawnPoints[_rr].transform);
        }
    }

}
