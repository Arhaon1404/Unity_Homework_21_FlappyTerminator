using System.Collections;
using UnityEngine;

public class EnemyBulletSpawner : Spawner<Bullet>
{
    [SerializeField] private Bot _bot;
    [SerializeField] private float _fireRate;

    private WaitForSeconds _bulletFireRate;

    private void OnEnable()
    {
        StartCoroutine(CreateBulletCoroutine());
    }

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

        bullet.GetDirection(_bot.BotDirection);

        base.OnTakeFromPool(bullet);
    }

    protected override Bullet CreateObject()
    {
        Bullet bullet = Instantiate(Prefab, SpawnPosition, transform.rotation);

        bullet.GetBulletState(true);

        return bullet;
    }

    private void Release(Bullet bullet)
    {
        bullet.ContactOccurred -= Release;

        Pool.Release(bullet);
    }
}


