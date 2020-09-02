using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{

    [Tooltip("L'élement 0 doit être la partie gauche de l'arbre, l'élément 1 la partie du milieu et l'élement 2 la partie de droite")]
    public GameObject[] path;
    private GameObject endPTransform;
    public int objToGen;
    private int loop;

    public List<GameObject> endPlatform = new List<GameObject>();

    public void Start()
    {
        loop = 0;
        Generate();
        //treeHolder = FindObjectOfType<TreeController>().gameObject;
    }

    public void Generate()
    {
        if(objToGen >= loop)
        {
            endPTransform = GameObject.FindWithTag("endPlatform");

            for (int i = 0; i <= objToGen; i++)
            {
                loop++;

                int PathNbr = Random.Range(0, 10);

                if (PathNbr == 0)//LEFT
                {
                    GameObject go = Instantiate(path[0], endPTransform.transform.position, Quaternion.identity);
                    //go.transform.SetParent(transform.parent);
                    endPTransform.SetActive(false);
                    i = objToGen;
                    path[0].GetComponent<TreePartController>().ThePart();
                    //Debug.Log("0");
                }
                else if (PathNbr == 1)//RIGHT
                {
                    GameObject go = Instantiate(path[2], endPTransform.transform.position, Quaternion.identity);
                    //go.transform.SetParent(transform.parent);
                    endPTransform.SetActive(false);
                    i = objToGen;
                    path[2].GetComponent<TreePartController>().ThePart();
                    //Debug.Log("1");
                }
                else if (PathNbr > 2)
                {
                    //Debug.Log("the else");
                    GameObject go = Instantiate(path[1], endPTransform.transform.position, Quaternion.identity);
                    //go.transform.SetParent(transform.parent);
                    endPTransform.SetActive(false);
                }

                foreach (GameObject endPlatTransform in GameObject.FindGameObjectsWithTag("endPlatform"))
                {
                    endPlatform.Clear();
                    endPlatform.Add(endPlatTransform);
                    endPTransform = endPlatTransform;
                }
            }
        }
        else
        {
            Debug.Log("no more tree to instantiate");
        }
    }
}
