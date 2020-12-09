using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder towerBuilder;

    private List<Block> blocks;

    private void Start()
    {
        towerBuilder = GetComponent<TowerBuilder>();
        blocks = towerBuilder.Build();

        foreach (var block in blocks)
        {
            block.BulletHit += OnBulletHit;
        }
    }

    private void OnBulletHit(Block hittedBlock)
    {
        hittedBlock.BulletHit -= OnBulletHit;

        blocks.Remove(hittedBlock);

        foreach (var block in blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
    }
}
