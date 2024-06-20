using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : StaticMovableObject
{
    public Vector2 Direction => _direction;

    private void Awake()
    {
        _direction = Vector2.left;
    }
}
