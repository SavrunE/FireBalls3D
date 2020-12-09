using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    public bool FlipRotate;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        if (FlipRotate)
        {
            RotateY(-rotateSpeed);
        }
        else
        {
            RotateY(rotateSpeed);
        }

    }

    private void RotateY(float rotateSpeed)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime, 0));
    }
}
