using UnityEngine;
public class VerticalAnimation : MonoBehaviour
{
    void Start()
    {
        LeanTween.moveY(gameObject,4.5f,1.8f).setEaseInOutCubic().setLoopPingPong();
    }
}
