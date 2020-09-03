using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{

    [Tooltip("L'élement 0 doit être la partie gauche de l'arbre, l'élément 1 la partie du milieu et l'élement 2 la partie de droite")]
    public GameObject[] path;
    private GameObject endPTransform;
    public int objToGen;
    private int loop;

    public GameObject centerSouterrain;
    public GameObject leftSouterrain;
    public GameObject rightSouterrain;
    public GameObject rightToCenterSouterrain;
    //public GameObject leftToCenterSouterrain;

    public GameObject trouExt;
    public GameObject trouInt;

    //public GameObject centerTreeDark;

    [Tooltip("Distance minimal du souterrain (prenez les mètres pour ref")]
    public int lengthOfSouterrainMin;
    [Tooltip("Distance maximal du souterrain (prenez les mètres pour ref")]
    public int lengthOfSouterrainMax;
    [Tooltip("Probabilité qu'un virage à gauche soit généré sur 100 dans le souterrain -- Par défaut à 25")]
    public int LeftSouterrainProb = 25;
    [Tooltip("Probabilité qu'un virage à droite soit généré sur 100 dans le souterrain -- Par défaut à 25")]
    public int RightSouterrainProb = 25;

    [Tooltip("Probabilité qu'un virage à gauche soit généré sur 100 -- Par défaut à 10 cst ok")]
    public float LeftProb = 10;
    [Tooltip("Probabilité qu'un virage à droite soit généré sur 100 -- Par défaut à 10 cst ok")]
    public float RightProb = 10;
    [Tooltip("Probabilité qu'un souterrain soit généré sur 100 -- Par défaut à 5")]
    public float Souterrain = 5;

    [Tooltip("Alpha entre 0 et 1 du tronc extérieur quand on est dans l'intérieur du tronc")]
    [Range(0.0f, 1.0f)]
    public float alphaSouterrain;

    private bool canSouterrain;

    private float savePart;

    private bool alreadyLeft;
    private bool alreadyRight;

    public List<GameObject> endPlatform = new List<GameObject>();

    public List<SpriteRenderer> darkPart = new List<SpriteRenderer>();

    public void Start()
    {
        savePart = 102;
        //Debug.Log(LeftSouterrainProb + " : leftsouterrainprob");
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
                Debug.Log(loop);

                int PathNbr = Random.Range(0, 100);

                if (PathNbr <= LeftProb)//LEFT
                {
                    GameObject go = Instantiate(path[0], endPTransform.transform.position, Quaternion.identity);
                    //go.transform.SetParent(transform.parent);
                    endPTransform.SetActive(false);
                    i = objToGen;
                    path[0].GetComponent<TreePartController>().ThePart();
                    //Debug.Log("0");
                }
                else if (LeftProb < PathNbr && PathNbr <= LeftProb + RightProb)//RIGHT
                {
                    GameObject go = Instantiate(path[2], endPTransform.transform.position, Quaternion.identity);
                    //go.transform.SetParent(transform.parent);
                    endPTransform.SetActive(false);
                    i = objToGen;
                    path[2].GetComponent<TreePartController>().ThePart();
                    //Debug.Log("1");
                }
                else if (RightProb + LeftProb < PathNbr && PathNbr <= LeftProb + RightProb + Souterrain /*&& !canSouterrain*/)//SOUTERRAIN
                {
                    Debug.Log("vdfv");
                    if (0==0)
                    {
                        //canSouterrain = true;
                        Debug.Log("generation souterrain");
                        TrouDark();

                        endPTransform = GameObject.FindWithTag("endPlatform");

                        var rr = Random.Range(lengthOfSouterrainMin, lengthOfSouterrainMax + 1);

                        for (int j = 0; j < rr; j++)
                        {
                            if (j != rr - 1)
                            {
                                int ProbPart = Random.Range(0, 100);
                               // Debug.Log("Prob part : " + ProbPart + " -- boucle :  " + j);
                                if (ProbPart <= LeftSouterrainProb)
                                {
                                    if (savePart <= ProbPart)
                                    {
                                        j++;
                                        Debug.Log("part identique à la précédente");
                                    }
                                    else
                                    {
                                        if (alreadyLeft)
                                        {
                                            savePart = ProbPart;
                                            GameObject _go = Instantiate(rightSouterrain, endPTransform.transform.position, Quaternion.identity);
                                            _go.transform.GetChild(0).gameObject.SetActive(false);
                                            endPTransform.SetActive(false);
                                            GameObject go = Instantiate(path[2], endPTransform.transform.position, Quaternion.identity);
                                            endPTransform.SetActive(false);
                                            foreach (SpriteRenderer darkParts in go.transform.GetComponentsInChildren<SpriteRenderer>())
                                            {
                                                darkPart.Add(darkParts);
                                            }
                                            i = objToGen;
                                            alreadyLeft = false;
                                            alreadyRight = false;
                                        }
                                        else if (alreadyRight)
                                        {
                                            savePart = ProbPart;
                                            GameObject _go = Instantiate(leftSouterrain, endPTransform.transform.position, Quaternion.identity);
                                            _go.transform.GetChild(0).gameObject.SetActive(false);
                                            _go.name = "ntm";
                                            endPTransform.SetActive(false);
                                            GameObject go = Instantiate(path[0], endPTransform.transform.position, Quaternion.identity);
                                            endPTransform.SetActive(false);
                                            foreach (SpriteRenderer darkParts in go.transform.GetComponentsInChildren<SpriteRenderer>())
                                            {
                                                darkPart.Add(darkParts);
                                            }
                                            i = objToGen;
                                            alreadyLeft = false;
                                            alreadyRight = false;
                                        }
                                        else
                                        {
                                            savePart = ProbPart;
                                            GameObject _go = Instantiate(leftSouterrain, endPTransform.transform.position, Quaternion.identity);
                                            _go.transform.GetChild(0).gameObject.SetActive(false);
                                            _go.name = "ntm";
                                            endPTransform.SetActive(false);
                                            GameObject go = Instantiate(path[0], endPTransform.transform.position, Quaternion.identity);
                                            endPTransform.SetActive(false);
                                            foreach (SpriteRenderer darkParts in go.transform.GetComponentsInChildren<SpriteRenderer>())
                                            {
                                                darkPart.Add(darkParts);
                                            }
                                            i = objToGen;
                                            alreadyLeft = true;
                                            alreadyRight = false;
                                        }


                                    }

                                }
                                else if (LeftSouterrainProb < ProbPart && ProbPart <= LeftSouterrainProb + RightSouterrainProb)
                                {
                                    if (savePart < ProbPart && ProbPart <= LeftSouterrainProb + RightSouterrainProb && alreadyRight)
                                    {
                                        j++;
                                        Debug.Log("part identique à la précédente");
                                    }
                                    else
                                    {
                                        if (alreadyRight)
                                        {
                                            GameObject _go = Instantiate(leftSouterrain, endPTransform.transform.position, Quaternion.identity);
                                            _go.transform.GetChild(0).gameObject.SetActive(false);
                                            _go.name = "ntm";
                                            endPTransform.SetActive(false);
                                            GameObject go = Instantiate(path[0], endPTransform.transform.position, Quaternion.identity);
                                            endPTransform.SetActive(false);
                                            foreach (SpriteRenderer darkParts in go.transform.GetComponentsInChildren<SpriteRenderer>())
                                            {
                                                darkPart.Add(darkParts);
                                            }
                                            i = objToGen;
                                            alreadyLeft = false;
                                            alreadyRight = false;
                                        }
                                        else if (alreadyLeft)
                                        {
                                            savePart = ProbPart;
                                            GameObject _go = Instantiate(rightSouterrain, endPTransform.transform.position, Quaternion.identity);
                                            _go.transform.GetChild(0).gameObject.SetActive(false);
                                            endPTransform.SetActive(false);
                                            GameObject go = Instantiate(path[2], endPTransform.transform.position, Quaternion.identity);
                                            endPTransform.SetActive(false);
                                            foreach (SpriteRenderer darkParts in go.transform.GetComponentsInChildren<SpriteRenderer>())
                                            {
                                                darkPart.Add(darkParts);
                                            }
                                            i = objToGen;
                                            alreadyRight = false;
                                            alreadyLeft = false;
                                        }
                                        else
                                        {
                                            GameObject _go = Instantiate(rightSouterrain, endPTransform.transform.position, Quaternion.identity);
                                            _go.transform.GetChild(0).gameObject.SetActive(false);
                                            endPTransform.SetActive(false);
                                            GameObject go = Instantiate(path[2], endPTransform.transform.position, Quaternion.identity);
                                            endPTransform.SetActive(false);
                                            foreach (SpriteRenderer darkParts in go.transform.GetComponentsInChildren<SpriteRenderer>())
                                            {
                                                darkPart.Add(darkParts);
                                            }
                                            i = objToGen;
                                            alreadyRight = true;
                                            alreadyLeft = false;
                                        }

                                    }
                                }
                                else
                                {
                                    //Debug.Log("fin?");
                                    GameObject _go = Instantiate(centerSouterrain, endPTransform.transform.position, Quaternion.identity);
                                    _go.transform.GetChild(0).gameObject.SetActive(false);
                                    endPTransform.SetActive(false);
                                    GameObject go = Instantiate(path[1], endPTransform.transform.position, Quaternion.identity);
                                    endPTransform.SetActive(false);
                                    foreach (SpriteRenderer darkParts in go.transform.GetComponentsInChildren<SpriteRenderer>())
                                    {
                                        darkPart.Add(darkParts);
                                    }
                                    i = objToGen;
                                }
                            }
                            else
                            {
                                GameObject _go = Instantiate(centerSouterrain, endPTransform.transform.position, Quaternion.identity);
                                _go.transform.GetChild(0).gameObject.SetActive(false);
                                endPTransform.SetActive(false);
                                Debug.Log("fin?");
                                GameObject go = Instantiate(trouInt, endPTransform.transform.position, Quaternion.identity);
                                Debug.Log(go.name = "f");
                                //go.transform.GetChild(0).gameObject.SetActive(false);
                                foreach (SpriteRenderer darkParts in go.transform.GetComponentsInChildren<SpriteRenderer>())
                                {
                                    darkPart.Add(darkParts);
                                }

                                //INSTANTIATE FIN DE SOUTERRAIN AVEC SORTIE
                                endPTransform.SetActive(false);
                                i = objToGen;
                                loop = 0;
                                
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
                        Generate();
                    }

                }
                else if(PathNbr > LeftProb + RightProb + Souterrain)
                {
                    //Debug.Log("the else");
                    Instantiate(path[1], endPTransform.transform.position, Quaternion.identity);
                    
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

    public void GoInDark()
    {
        for(int i = 0; i < darkPart.Count; i++)
        {
            Color tmp = darkPart[i].color;
            tmp.a = alphaSouterrain;
            darkPart[i].color = tmp;
        }
    }

    public void GoInExt()
    {
        for (int i = 0; i < darkPart.Count; i++)
        {
            Color tmp = darkPart[i].color;
            tmp.a = 1;
            darkPart[i].color = tmp;
        }
    }

    void TrouDark()
    {
        Instantiate(trouExt, endPTransform.transform.position, Quaternion.identity);
        endPTransform.SetActive(false);

        foreach (GameObject endPlatTransform in GameObject.FindGameObjectsWithTag("endPlatform"))
        {
            endPlatform.Clear();
            endPlatform.Add(endPlatTransform);
            endPTransform = endPlatTransform;
        }
    }

}
