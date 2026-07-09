using UnityEngine;

public class PressStartText : MonoBehaviour
{
    public float blinkSpeed = 2f;

    private CanvasGroup canvasGroup;
    private float blinkTimer = 0f;
    private bool isVisible = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        ShowText();
    }

    void Update()
    {
        if (!isVisible)
            return;

        blinkTimer += Time.deltaTime;
        canvasGroup.alpha = Mathf.PingPong(blinkTimer * blinkSpeed, 1f);
    }

    public void ShowText()
    {
        isVisible = true;
        blinkTimer = 0f;
        canvasGroup.alpha = 1f;
    }

    public void HideText()
    {
        isVisible = false;
        canvasGroup.alpha = 0f;
    }
}