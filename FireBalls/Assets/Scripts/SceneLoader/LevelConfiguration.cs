using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Config", menuName = "Config")]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private int towerSize;
    public int TowerSize => TowerSize;

    [SerializeField] private int tankAditionalProjectiles;
    public int TankAditionalProjectiles => tankAditionalProjectiles;
}
