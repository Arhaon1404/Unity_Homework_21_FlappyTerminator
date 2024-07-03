using System;
using UnityEngine;

[RequireComponent(typeof(Bot))]

public class BotCollisionDetector : MonoBehaviour
{
    private Bot _bot;

    private bool _isDestroy;

    private void Awake()
    {
        _bot = GetComponent<Bot>();
        _isDestroy = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            if (bullet.IsEnemyBullet == false)
            {
                _bot.ContactOccur(_isDestroy);
                bullet.ContactOccur();
            }
        }
    }
}
