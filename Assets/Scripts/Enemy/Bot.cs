using System;
using UnityEngine;

public class Bot : StaticMovableObject
{
    public Vector2 Direction => _direction;

    public event Action<Bot> ContactOccurred;
    public event Action<Bot> BotDestroyed;

    private void Awake()
    {
        _direction = Vector2.left;
    }

    public void ContactOccur(bool isDestroy)
    {
        if (isDestroy)
        {
            BotDestroyed?.Invoke(this);
        }
        else
        {
            ContactOccurred?.Invoke(this);
        }
    }
}
