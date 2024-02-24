using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
  public float velocity = 5f;  
    public float distance = 10f; 

    private Vector3 InitalPosition;

    void Start()
    {
      
        InitalPosition = transform.position;
    }

    void Update()
    {
    
        Move();
    }

    void Move()
    {
        
        float desplazamiento = velocity * Time.deltaTime;

       
        transform.Translate(Vector3.right * desplazamiento);

    
        if (Mathf.Abs(transform.position.x - InitalPosition.x) >= distance)
        {
        
            velocity = -velocity;
        }
    }
}
