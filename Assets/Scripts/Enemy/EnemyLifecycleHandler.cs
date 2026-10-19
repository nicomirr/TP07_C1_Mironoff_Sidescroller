using UnityEngine;
using System.Collections;
using Game.Data;

public class EnemyLifecycleHandler : MonoBehaviour
{
    [SerializeField] private EnemyLifecycleHandlerDataSo _data;

    [SerializeField] private GameObject _enemyObject;

    private LootDropper _lootDropper;

    private Vector2 _enemyInitialPos;

    private Coroutine _respawnRoutine;

    private IReset _enemyReset;

    private void Awake()
    {
        _enemyReset = _enemyObject.GetComponent<IReset>();

        _lootDropper = new LootDropper(_data.LootDropperData, _enemyObject.transform);
    }

    private void Start()
    {
        _enemyInitialPos = _enemyObject.transform.position;
    }

    private void Update()
    {
        if (_enemyObject.gameObject.activeSelf) return;

        if (_respawnRoutine != null) return;

        _respawnRoutine = StartCoroutine(RespawnRoutine());
    }

    private IEnumerator RespawnRoutine()
    {
        _lootDropper.DropLoot();

        yield return new WaitForSeconds(10);

        _enemyObject.transform.position  = _enemyInitialPos;
        _enemyObject.SetActive(true);

        _enemyReset.ResetObject();

        _respawnRoutine = null;
    }
}
