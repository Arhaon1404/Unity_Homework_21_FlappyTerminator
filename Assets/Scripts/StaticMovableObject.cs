using UnityEngine;

public class StaticMovableObject : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Vector2 _direction;

    protected virtual void Update()
    {
        transform.Translate(_direction * _speed);
    }
}
