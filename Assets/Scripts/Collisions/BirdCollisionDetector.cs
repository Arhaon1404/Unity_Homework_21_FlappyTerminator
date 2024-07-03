using UnityEngine;

public class BirdCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            if (bullet.IsEnemyBullet)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent(out Floor floor))
        {
            Destroy(gameObject);
        }
    }
}
