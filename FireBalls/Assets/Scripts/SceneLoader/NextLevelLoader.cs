using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private LevelConfiguration levelConfiguration;

    private void OnEnable()
    {
        tower.SizeChanged += OnTowerSizeChanged;
    }
    private void OnDisable()
    {

        tower.SizeChanged -= OnTowerSizeChanged;
    }

    private void OnTowerSizeChanged(int size)
    {
        if (size == 0)
        {
            MainLevel.Load(levelConfiguration);
        }
    }
}
