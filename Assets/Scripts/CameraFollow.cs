using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    private MenuButtons menuButtons;
    public Rigidbody target;
    public Vector3 offset;
    public Transform offsetTarget;
    private float SmoothSpeed = 5.75f;
    private void Start() 
    {
        menuButtons = GameObject.FindGameObjectWithTag("InGameCanvas").GetComponent<MenuButtons>();
        target = GameObject.Find("Player Cube").GetComponent<Rigidbody>();  
        offsetTarget = GameObject.FindGameObjectWithTag("lookoffset").GetComponent<Transform>();  
    }
    private void Update() 
    {
        if (menuButtons.gameStarted)
        {
            Vector3 DesiredPosition = target.position + offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position,DesiredPosition,SmoothSpeed * Time.deltaTime);
            transform.position = SmoothedPosition;
            transform.LookAt(offsetTarget);
        }    
    }
}