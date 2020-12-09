using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float towerSize;
    [SerializeField] private Transform buildPoint;
    [SerializeField] private Block block;

    private List<Block> blocks;

    public List<Block> Build()
    {
        blocks = new List<Block>();

        Transform currentPoint = buildPoint;

        for (int i = 0; i < towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        return blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(block, GetBuildPoint(currentBuildPoint), Quaternion.identity, buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(buildPoint.position.x, 
            currentSegment.position.y + currentSegment.localScale.y / 2 + block.transform.localScale.y / 2,
            buildPoint.position.z);
    }
}