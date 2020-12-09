using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ObstacleRotator parentRotator;
    private void Start()
    {
        parentRotator = transform.parent.GetComponent<ObstacleRotator>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Debug.Log(parentRotator);
            parentRotator.FlipRotate = !parentRotator.FlipRotate;
        }
    }
}
