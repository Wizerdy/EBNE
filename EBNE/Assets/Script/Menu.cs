using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BouttonJouer()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BouttonBoutique()
    {
        SceneManager.LoadScene("Boutique");
    }

    public void BouttonQuitter  ()
    {
        Application.Quit();
    }
}
