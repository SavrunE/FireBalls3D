using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 moverDirection;

    private void Start()
    {
        moverDirection = Vector3.forward;
    }
    private void Update()
    {
        transform.Translate(moverDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
    }
}
