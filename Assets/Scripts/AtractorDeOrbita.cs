using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractorDeOrbita : MonoBehaviour
{
      public float radioDeAtraccion = 5f;
    public float fuerzaDeAtraccion = 10f;
    private void Update() {
         AtraerObjetosCercanos();
    }

    void AtraerObjetosCercanos()
    {
        Collider[] objetosCercanos = Physics.OverlapSphere(transform.position, radioDeAtraccion);

        foreach (Collider objeto in objetosCercanos)
        {
            // Verifica si el objeto tiene un Rigidbody y no es el propio objeto atractor
            if (objeto.CompareTag("Atractable") && objeto.GetComponent<Rigidbody>() != null && objeto.gameObject != gameObject)
            {
                Rigidbody rb = objeto.GetComponent<Rigidbody>();

                // Calcula la dirección hacia el objeto atractor
                Vector3 direccion = transform.position - objeto.transform.position;

                // Calcula la fuerza de atracción
                float distancia = direccion.magnitude;
                float fuerza = fuerzaDeAtraccion * (rb.mass / Mathf.Pow(distancia, 2));

                // Aplica la fuerza al objeto
                rb.AddForce(direccion.normalized * fuerza);
            }
        }
    }
}
