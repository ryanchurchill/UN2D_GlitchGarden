using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab;

    public void SetSelectedDefender(Defender defenderPrefabToSelect)
    {
        defenderPrefab = defenderPrefabToSelect;
    }

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 SpawnLocation)
    {
        Defender newDefender = Instantiate(defenderPrefab, SpawnLocation, Quaternion.identity) as Defender;
    }
}
