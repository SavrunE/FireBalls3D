using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float bounceForce;
    [SerializeField] private float bounceRadius;

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
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
    }
    private void Bounce()
    {
        moverDirection = Vector3.back + Vector3.up;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(bounceForce, transform.position + new Vector3(0, -1, 1), bounceRadius);
    }
}
