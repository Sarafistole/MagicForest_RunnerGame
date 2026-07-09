using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image[] hearts;

    private void Update()
    {
        if (GameManager.Instance == null)
            return;

        int health = Mathf.Clamp(GameManager.Instance.playerHealth, 0, 3);

        for (int i = 0; i < hearts.Length; i++)
        {
            Color color = hearts[i].color;
            color.a = (i < health) ? 1f : 0.1f;
            hearts[i].color = color;
        }
    }
}