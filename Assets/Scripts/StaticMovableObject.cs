using UnityEngine;

public class StaticMovableObject : MonoBehaviour
{
    [SerializeField] protected float Speed;
    protected Vector2 Direction;

    protected virtual void Update()
    {
        transform.Translate(Direction * Speed);
    }
}
