using UnityEngine;

public class BirdShooter : Spawner<Bullet>
{
    private Vector2 _originalTransform;

    private void Start()
    {
        _originalTransform = transform.right;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Bullet bullet = Pool.Get();
            bullet.ContactOccurred += Release;
        }
    }

    public void Release(Bullet bullet)
    {
        Pool.Release(bullet);
        bullet.ContactOccurred -= Release;
    }

    protected override void OnTakeFromPool(Bullet bullet)
    {
        bullet.transform.position = transform.position;

        bullet.GetDirection(_originalTransform);

        base.OnTakeFromPool(bullet);
    }

    protected override Bullet CreateObject()
    {
        Bullet bullet = Instantiate(Prefab, SpawnPosition, transform.rotation);

        bullet.GetBulletState(false);

        return bullet;
    }

    protected override void OnReturnedToPool(Bullet bullet)
    {
        bullet.transform.rotation = transform.rotation;

        base.OnReturnedToPool(bullet);
    }
}
