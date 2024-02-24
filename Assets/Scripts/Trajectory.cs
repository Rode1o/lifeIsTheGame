using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
      public Projectile gunScript;

      LineRenderer renderer;

      public int numpoints = 50;

      public float timeBetweenPoints = 0.1f;

      public LayerMask CollidableLayers;

      private void Start() {
        gunScript = GetComponent<Projectile>();
        renderer =  GetComponent<LineRenderer>();
      }

      private void Update() {
        renderer.positionCount = numpoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = gunScript.attackPoint.position;
        Vector3 startingVelocity = gunScript.attackPoint.up * gunScript.shootForce;

        for (float i = 0; i < numpoints; i += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + i * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * i + Physics.gravity.y/2 * i * i;
            points.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
            {
                renderer.positionCount = points.Count;
                break;
            }
            
        }
        renderer.SetPositions(points.ToArray());
      }


}
