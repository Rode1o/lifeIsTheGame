using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{

    public GameObject target;
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        GameObject Objective = GameObject.FindWithTag("Objective");
        if (Objective != null)
        {
            target = Objective;
        }
        this.transform.LookAt(target.transform);
        StartCoroutine(SendHoming());
    }

    public IEnumerator SendHoming()
    {
        while(Vector3.Distance(target.transform.position, this.transform.position)> 0.3f)
        {
            this.transform.position += (target.transform.position - this.transform.position).normalized * speed * Time.deltaTime;
            this.transform.LookAt(target.transform);
            yield return null;
        }
        Destroy(this);
    }
}
