using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [Header("End game effects")]
    [SerializeField] private ParticleSystem salute;
    [SerializeField] private GameObject winTitle;
    
    private TowerBuilder towerBuilder;

    private List<Block> blocks;

    public event UnityAction<int> SizeChanged;

    private void Start()
    {
        towerBuilder = GetComponent<TowerBuilder>();
        blocks = towerBuilder.Build();

        foreach (var block in blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        SizeChanged?.Invoke(blocks.Count);
    }

    private void OnBulletHit(Block hittedBlock)
    {
        hittedBlock.BulletHit -= OnBulletHit;

        blocks.Remove(hittedBlock);

        foreach (var block in blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x,
                block.transform.position.y - block.transform.localScale.y,
                block.transform.position.z);
        }
        SizeChanged?.Invoke(blocks.Count);
        if (blocks.Count == 0)
        {
            OnWin();
        }
    }
    private void OnWin()
    {
        Instantiate(salute, transform.position, Quaternion.Euler(-90,0,0));
        salute.Play();
        winTitle.SetActive(true);
    }
}
