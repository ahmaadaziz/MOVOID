using UnityEngine;
public class MovingObstacle : MonoBehaviour
{
    private Vector3 currentPosition;
    private Vector3 smoothPositon;
    private Vector3 desiredPos;
    private float t = 0.5f;
    private void Start() 
    {
         currentPosition = transform.position;
         desiredPos = new Vector3(currentPosition.x,currentPosition.y,currentPosition.z*2);
    }
    private void Update() 
    {
        if (smoothPositon.z == currentPosition.z*2)
        {
             smoothPositon = Vector3.Lerp(desiredPos, currentPosition, t);
             transform.position = smoothPositon;
        }
        else
        {
             smoothPositon = Vector3.Lerp(currentPosition,desiredPos,t);
             transform.position = smoothPositon;
        }
    }
}
