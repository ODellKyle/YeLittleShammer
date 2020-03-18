using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectileprefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("EShoot");
    }

    void Shoot()
    {
        Instantiate(projectileprefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator EShoot() 
    {
        for (float i = 1f; i >= 0; i -= .1f) 
        {
            Shoot();
            yield return new WaitForSeconds(.5f);
        }
    }
}
