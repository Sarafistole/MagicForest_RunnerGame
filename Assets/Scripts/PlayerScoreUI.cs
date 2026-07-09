using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (GameManager.Instance != null)
        {
            int roundedScore = Mathf.RoundToInt(GameManager.Instance.playerScore);
            scoreText.text = roundedScore.ToString("D3");
        }
    }
}