using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BestScoreText : MonoBehaviour
{

    private TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        bestScoreText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance == null)
            return;

        bestScoreText.text = GameManager.Instance.bestScore.ToString("D3");
        
    }
}
