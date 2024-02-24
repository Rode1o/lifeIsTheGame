using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject bullet;

    public static Projectile instance;

    private List<GameObject> pool = new List<GameObject>();
    public float rotationSpeed = 1;

    public float shootForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShoot;
    public int magazineSize, bulletsPerTap;

    public bool allowButtonhold;

    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Start() {
        for (int i = 0; i < magazineSize; i++)
        {
            GameObject obj = Instantiate(bullet, attackPoint.position, Quaternion.identity, attackPoint.position, Quaternion.identity);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    private void Update() {
        MyInput();
    }

    private void MyInput()
    {
        if (allowButtonhold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 directionWithOutSpread = targetPoint - attackPoint.position;

        GameObject currentBullet = pool.instance.GetPooledObject();

        if (currentBullet == null)
        {
            return;

        }
        currentBullet.SetActive(true);
        currentBullet.transform.forward = directionWithOutSpread;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithOutSpread * shootForce, ForceMode.Impulse);
        // currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
        bulletsLeft --;
        bulletsShot ++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if(bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShoot);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
            
        }
        return null;
    }
}
