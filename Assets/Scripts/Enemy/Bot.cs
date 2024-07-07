using System;
using UnityEngine;

public class Bot : StaticMovableObject
{
    public Vector2 BotDirection => Direction;

    public event Action<Bot> ContactOccurred;
    public event Action<Bot> BotDestroyed;

    private void Awake()
    {
        Direction = Vector2.left;
    }

    public void ContactOccur()
    {
        ContactOccurred?.Invoke(this);
    }

    public void BotDestroy()
    {
        BotDestroyed?.Invoke(this);
    }
}
