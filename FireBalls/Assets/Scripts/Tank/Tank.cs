using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Projectile projectile;
    [SerializeField] private float delayBetweenShoot;

    private float timeAfterShoot;

    private void Update()
    {
        timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (timeAfterShoot > delayBetweenShoot)
            {
                Shoot();
                timeAfterShoot = 0;
            }
        }
    }
    private void Shoot()
    {
        Instantiate(projectile, shootPoint.position, Quaternion.identity);
    }
}
