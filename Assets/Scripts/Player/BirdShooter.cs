using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShooter : Spawner<Bullet>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
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

        bullet.GetDirection(transform.right);

        return bullet;
    }

    public void Release(Bullet bullet)
    {
        Pool.Release(bullet);
        bullet.ContactOccurred -= Release;
    }
}
