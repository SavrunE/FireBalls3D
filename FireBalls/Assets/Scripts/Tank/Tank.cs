using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Projectile[] projectiles;
    [SerializeField] private float delayBetweenShoot;
    [SerializeField] private float recoilDistance;
    [SerializeField] private float rotateAngle = -20f;
    [SerializeField] private int aditionalProjectile;
    [SerializeField] private TowerBuilder towerBuilder;

    private bool canShoot;
    private int projectileCount;
    private float timeAfterShoot;

    public event UnityAction<int> ProjectileSizeChanged;

    private void Start()
    {
        canShoot = true;
        if (aditionalProjectile < 0)
        {
            aditionalProjectile = 0;
        }

        int towerSize = towerBuilder.TowerSize;
        projectileCount = towerSize + aditionalProjectile;
        ProjectileSizeChanged?.Invoke(projectileCount);
    }
    private void Update()
    {
        timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (timeAfterShoot > delayBetweenShoot && canShoot)
            {
                projectileCount--;
                if (projectileCount == 0)
                {
                    canShoot = false;
                    StartCoroutine(EndLevel());
                }
                ProjectileSizeChanged?.Invoke(projectileCount);

                Shoot();
                transform.DOMoveZ(transform.position.z - recoilDistance, delayBetweenShoot / 2).SetLoops(2, LoopType.Yoyo);
                transform.DORotate(new Vector3(rotateAngle, 0, 0), delayBetweenShoot / 2, RotateMode.Fast).SetLoops(2, LoopType.Yoyo);
                timeAfterShoot = 0;
            }
        }
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
    private void Shoot()
    {
        Instantiate(projectiles[Random.Range(0, projectiles.Length)], shootPoint.position, Quaternion.identity);
    }
}
