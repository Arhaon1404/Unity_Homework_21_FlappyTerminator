using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            bullet.ContactOccur();
        }

        if (collision.gameObject.TryGetComponent(out Bot bot))
        {
            bot.ContactOccur();
        }
    }
}
