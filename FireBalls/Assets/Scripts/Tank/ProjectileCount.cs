using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileCount : MonoBehaviour
{
    [SerializeField] private TMP_Text sizeText;
    [SerializeField] private Tank tank;
    private void OnEnable()
    {
        tank.ProjectileSizeChanged += ChangeProjectileCount;
    }
    private void OnDisable()
    {

        tank.ProjectileSizeChanged -= ChangeProjectileCount;
    }
    private void ChangeProjectileCount(int projectileBalance)
    {
        sizeText.text = projectileBalance.ToString();
    }
}
