using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private float invulnerabilityTime = 1f;

    private float lastHitTime = -Mathf.Infinity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        if (Time.time - lastHitTime < invulnerabilityTime)
            return;

        lastHitTime = Time.time;
        GameManager.Instance.playerHealth = Mathf.Max(0, GameManager.Instance.playerHealth - 1);
    }
}