using Supyrb;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressionSystem : MonoBehaviour
{
    private Signal levelWinSignal;
    private Signal endPointReachedSignal;

    private int endPointReachedCount;
    private int requirementCount;

    private void Start()
    {
        endPointReachedSignal = Signals.Get<EndPointReachedSignal>();
        levelWinSignal = Signals.Get<LevelWinSIgnal>();
        endPointReachedSignal.AddListener(EndPointReached);
    }

    private void EndPointReached()
    {
        endPointReachedCount++;

        if (requirementCount == 0)
            requirementCount = FindObjectsOfType<Cube>().Length;

        if (endPointReachedCount == requirementCount)
            LevelWin();
    }

    private void LevelWin()
    {
        int level = PlayerPrefs.GetInt("Level", 1);
        level++;
        PlayerPrefs.SetInt("Level", level);
        levelWinSignal?.Dispatch();
    }

    private void OnDestroy()
    {
        endPointReachedSignal.RemoveListener(EndPointReached);
    }
}
