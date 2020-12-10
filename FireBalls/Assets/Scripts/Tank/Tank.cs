using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Projectile projectile;
    [SerializeField] private float delayBetweenShoot;
    [SerializeField] private float recoilDistance;
    [SerializeField] private float rotateAngle = -20f;

    private float timeAfterShoot;

    private void Update()
    {
        timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (timeAfterShoot > delayBetweenShoot)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - recoilDistance, delayBetweenShoot / 2).SetLoops(2, LoopType.Yoyo);
                transform.DORotate(new Vector3(rotateAngle, 0, 0), delayBetweenShoot / 2, RotateMode.Fast).SetLoops(2, LoopType.Yoyo);
                timeAfterShoot = 0;

            }
        }
    }
    private void Shoot()
    {
        Instantiate(projectile, shootPoint.position, Quaternion.identity);
    }
}
