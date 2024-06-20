using System.Collections;
using UnityEngine;

public class EnemyBulletSpawner : Spawner<Bullet>
{
    [SerializeField] private Bot _bot;
    [SerializeField] private float _fireRate;

    private WaitForSeconds _bulletFireRate;

    protected override void Awake()
    {
        base.Awake();

        _bulletFireRate = new WaitForSeconds(_fireRate);

        StartCoroutine(CreateBulletCoroutine());
    }

    private IEnumerator CreateBulletCoroutine()
    {
        while (true)
        {
            yield return _bulletFireRate;

            Bullet bullet = Pool.Get();

            bullet.ContactOccurred += Release;
        }
    }

    protected override void OnTakeFromPool(Bullet bullet)
    {
        bullet.transform.position = transform.position;
        base.OnTakeFromPool(bullet);
    }

    protected override Bullet CreateObject()
    {
        Bullet bullet = Instantiate(Prefab, SpawnPosition, transform.rotation);

        bullet.GetDirection(_bot.Direction);

        return bullet;
    }

    private void Release(Bullet bullet)
    {
        bullet.ContactOccurred -= Release;

        Pool.Release(bullet);
    }
}


