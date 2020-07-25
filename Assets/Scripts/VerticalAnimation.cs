using UnityEngine;
public class VerticalAnimation : MonoBehaviour
{
    void Start()
    {
        LeanTween.moveY(gameObject,3f,1.5f).setEaseInOutCubic().setLoopPingPong();
    }
}
