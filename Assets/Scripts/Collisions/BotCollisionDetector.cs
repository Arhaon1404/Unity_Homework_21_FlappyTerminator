using UnityEngine;

[RequireComponent(typeof(Bot))]

public class BotCollisionDetector : MonoBehaviour
{
    private Bot _bot;

    private void Awake()
    {
        _bot = GetComponent<Bot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            if (bullet.IsEnemyBullet == false)
            {
                _bot.BotDestroy();
                bullet.ContactOccur();
            }
        }
    }
}
