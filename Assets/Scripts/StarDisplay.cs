using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;

    // cached components
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int numStars)
    {
        stars += numStars;
        UpdateDisplay();
    }

    public bool SpendStars(int numStars)
    {
        if (numStars > stars)
        {
            return false;
        }

        stars -= numStars;
        UpdateDisplay();

        return true;
    }
}
