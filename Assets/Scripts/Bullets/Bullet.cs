using System;
using UnityEngine;

public class Bullet : StaticMovableObject
{
    private bool _isEnemyBullet;

    public event Action<Bullet> ContactOccurred;

    public bool IsEnemyBullet => _isEnemyBullet;

    public void GetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void ContactOccur()
    {
        ContactOccurred?.Invoke(this);
    }

    public void GetBulletState(bool isEnemyBullet)
    { 
        _isEnemyBullet = isEnemyBullet;
    }
}
