using UnityEngine;
using TMPro; // Add this if using TextMeshPro
using UnityEngine.UI; // Add this for Unity's UI Text

public class FloatingText : MonoBehaviour
{
    public GameObject textPrefab; // Reference to the XR UI Canvas prefab
    private GameObject floatingTextInstance;

    public void ShowText(string message)
    {
        if (floatingTextInstance == null)
        {
            floatingTextInstance = Instantiate(textPrefab, transform);
            floatingTextInstance.transform.localPosition = Vector3.up; // Adjust as necessary

            // Set the scale proportionally to the parent object
            Vector3 parentScale = transform.localScale;
            floatingTextInstance.transform.localScale = new Vector3(1 / parentScale.x, 1 / parentScale.y, 1 / parentScale.z);
        }

        TextMeshProUGUI textMeshPro = floatingTextInstance.GetComponentInChildren<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            textMeshPro.text = message;
        }
        else
        {
            // Fallback for legacy text component
            Text legacyText = floatingTextInstance.GetComponentInChildren<Text>();
            if (legacyText != null)
            {
                legacyText.text = message;
            }
        }
        floatingTextInstance.SetActive(true);
    }

    public void HideText()
    {
        if (floatingTextInstance != null)
        {
            floatingTextInstance.SetActive(false);
        }
    }
}
