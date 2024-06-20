using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : StaticMovableObject
{
    public event Action<Bullet> ContactOccurred;

    public void GetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void ContactOccur()
    {
        ContactOccurred?.Invoke(this);
    }
}
