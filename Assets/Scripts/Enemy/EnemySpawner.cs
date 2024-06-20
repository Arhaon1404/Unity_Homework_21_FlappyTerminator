using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class EnemySpawner : Spawner<Bot>
{
    [SerializeField] private float _spawnRate;
    
    private BoxCollider2D _boxCollider;

    private WaitForSeconds _enemySpawnRate;

    protected override void Awake()
    {
        base.Awake();

        _boxCollider = GetComponent<BoxCollider2D>();

        _enemySpawnRate = new WaitForSeconds(_spawnRate);

        StartCoroutine(CreateEnemyCoroutine());
    }

    public void Release(Bot bot)
    {
        Pool.Release(bot);
    }

    protected override void OnTakeFromPool(Bot bot)
    {
        bot.transform.position = transform.position + CreateRandomPosition();
        base.OnTakeFromPool(bot);
    }

    private IEnumerator CreateEnemyCoroutine()
    {
        while (true)
        {
            yield return _enemySpawnRate;

            Bot bot = Pool.Get();
        }
    }

    private Vector3 CreateRandomPosition()
    {
        float bisection = 2;

        float localWidth = _boxCollider.size.x / bisection;
        float localLenght = _boxCollider.size.y / bisection;

        float axesX = Random.Range(-localWidth, localWidth);
        float axesY = Random.Range(-localLenght, localLenght);

        return new Vector2(axesX, axesY);
    }

    
}
