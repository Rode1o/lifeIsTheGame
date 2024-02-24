using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Grounds"))
        {
            gameObject.SetActive(false);
        }
    }
}
