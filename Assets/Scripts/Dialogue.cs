using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Image image1;
    public Image image2;

    private bool isImage1Active = true;

    void Start()
    {
        image1.gameObject.SetActive(isImage1Active);
        image2.gameObject.SetActive(!isImage1Active);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isImage1Active)
            {
                // Second image is active, close the panel
                ClosePanel();
            }
            else
            {
                SwitchImages();
            }
        }
    }

    void SwitchImages()
    {
        isImage1Active = !isImage1Active;

        image1.gameObject.SetActive(isImage1Active);
        image2.gameObject.SetActive(!isImage1Active);
    }

    void ClosePanel()
    {
        // Set the panel game object to inactive
        gameObject.SetActive(false);
    }
}
