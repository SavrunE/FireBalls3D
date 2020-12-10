using TMPro;
using UnityEngine;

public class TowerSize : MonoBehaviour
{
    [SerializeField] private TMP_Text sizeText;
    [SerializeField] private Tower tower;

    private void OnEnable()
    {
        tower.SizeChanged += OnSizeChanged;
    }
    private void OnDisable()
    {

        tower.SizeChanged -= OnSizeChanged;
    }
    private void OnSizeChanged(int size)
    {
        this.sizeText.text = size.ToString();
    }
}
