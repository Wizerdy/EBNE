using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public List<Transform> parallax;
    public Vector2 bounds;
    public float parallaxSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        //float cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        for (int i = 0; i < parallax.Count; i++)
        {
            for (int index = 0; index < parallax[i].childCount; index++)
            {
                parallax[i].GetChild(index).Translate(Vector2.left * parallaxSpeed * Time.deltaTime * ((float)(i + 1) / (float)(parallax.Count)));
                if(parallax[i].GetChild(index).position.x < bounds.x)
                {
                    parallax[i].GetChild(index).position = new Vector2(bounds.y, parallax[i].GetChild(index).position.y);
                }
            }
        }
    }
}
