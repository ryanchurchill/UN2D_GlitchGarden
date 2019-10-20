using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    bool isSelected = false;

    private void Start()
    {
        updateColorBasedOnIsSelected();
    }

    private void OnMouseDown()
    {
        unselectAllButtons();

        // select this button only
        isSelected = true;
        updateColorBasedOnIsSelected();
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

    private void unselectAllButtons()
    {
        foreach (DefenderButton defenderButton in FindObjectsOfType<DefenderButton>())
        {
            defenderButton.unselect();
        }
    }

    private void updateColorBasedOnIsSelected()
    {
        if (isSelected)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }

    public void unselect()
    {
        isSelected = false;
        updateColorBasedOnIsSelected();
    }
}
