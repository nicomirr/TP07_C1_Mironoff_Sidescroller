using UnityEngine;
using System.Collections.Generic;
using Game.Data;

public class LootDropper
{
    private readonly GameObject _droppable;

    private readonly float _dropChance;

    private readonly Transform _ownerTransform;

    public LootDropper(LootDropperDataSo data, Transform ownerTransform)
    {
        _droppable = data.DroppablePrefab;

        _dropChance = data.DropChance;
        
        _ownerTransform = ownerTransform;                
    }

    public void DropLoot()
    {
        int randomValue = Random.Range(1, 101);

        if (randomValue <= _dropChance)
            GameObject.Instantiate(_droppable, _ownerTransform.position, Quaternion.identity);
    }
}
