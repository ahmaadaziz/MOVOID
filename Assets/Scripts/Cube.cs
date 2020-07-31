using UnityEngine;
public class Cube : MonoBehaviour
{
    public bool changeProfile;
    private MenuButtons menuButtons;
    private Rigidbody rb;
    public Joystick joystick;
    public bool isInverted;
    public bool isTimeStopped;
    public float mH, mV;
    public float speed;
    public float horizontalSpeed;
    public int i;
    public float incPosBy = 82f;
    private float previousSpeed;
    private void Start()
    {
        i = 1;
        horizontalSpeed = 300f;
        speed = 400f;
        isInverted = false;
        isTimeStopped = false;
        changeProfile = false;
        rb = gameObject.GetComponent<Rigidbody>();
        menuButtons = GameObject.FindGameObjectWithTag("InGameCanvas").GetComponent<MenuButtons>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        previousSpeed = speed;
        speed = 0f;    
    }
    private void OnCollisionExit(Collision other) 
    {
        speed = previousSpeed;  
    }
    private void FixedUpdate() 
    {
        if (menuButtons.gameStarted)
        {
            mH = joystick.Horizontal * horizontalSpeed * Time.fixedDeltaTime;
            mV = speed * Time.fixedDeltaTime;
            if (isInverted)
            {
                mH = mH*-1f;
            }
            rb.velocity = new Vector3 (mH , 0, mV );
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
        }
    }
}
