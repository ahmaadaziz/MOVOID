using UnityEngine;
using TMPro;

public class SphereSize : MonoBehaviour
{
    public TextMeshProUGUI sizeText;
    private float scale;
    void Update()
    {
         scale = transform.localScale.x;
         sizeText.text = scale.ToString("#.##");
    }
}
