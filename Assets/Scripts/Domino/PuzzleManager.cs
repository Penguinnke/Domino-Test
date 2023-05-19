using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefabs;
    [SerializeField] private Transform _slotParent, _pieceParent;

    private void Start() {
        Spawn();
    }

    void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(1).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            var SpawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);

            var spawnedPiece = Instantiate(_piecePrefabs, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(SpawnedSlot);
        }

    }
}
