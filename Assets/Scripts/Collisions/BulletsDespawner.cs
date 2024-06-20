using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletsDespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            bullet.ContactOccur();
        }
    }
}
