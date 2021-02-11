using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class TowerBuilder : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    public int TowerSize { get; private set; }

    [SerializeField] private Transform buildPoint;
    [SerializeField] private Block block;
    [SerializeField] private Color[] colors;

    private List<Block> blocks;

    public List<Block> Build()
    {
        blocks = new List<Block>();

        Transform currentPoint = buildPoint;

        for (int i = 0; i < TowerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(colors[Random.Range(0, colors.Length)]);
            blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        return blocks;
    }

    public void OnSceneLoaded(LevelConfiguration argument)
    {
        TowerSize = argument.TowerSize;
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
