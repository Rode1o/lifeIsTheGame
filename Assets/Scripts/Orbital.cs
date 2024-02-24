using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital : MonoBehaviour
{
    public float Velocity = 50f;
    public Transform pivote;
    // Update is called once per frame
    void Update()
    {
        GameObject BlackHole = GameObject.FindWithTag("Hole");
        if (BlackHole != null)
        {
            pivote = BlackHole.transform;
        }
        if (pivote != null)
        {
           this.transform.RotateAround(pivote.transform.position, Vector3.up, Velocity); 
        }
       
    }
}
