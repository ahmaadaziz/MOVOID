using UnityEngine;
using UnityEngine.Rendering;
public class Cube : MonoBehaviour
{
    public bool changeProfile;
    private Volume volume;
    public VolumeProfile sloMO;
    public VolumeProfile main;
    private MenuButtons menuButtons;
    private Rigidbody rb;
    public Joystick joystick;
    public bool isInverted;
    public bool isTimeStopped;
    public float mH, mV;
    public bool isMoving;
    public float speed = 9f;
    public float horizontalSpeed = 10f;
    public int i;
    public float incPosBy = 82f;
    private float slowFactor;
    private void Start()
    {
        i = 1;
        rb = gameObject.GetComponent<Rigidbody>();
        isInverted = false;
        isTimeStopped = false;
        changeProfile = false;
        volume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>();
        menuButtons = GameObject.FindGameObjectWithTag("InGameCanvas").GetComponent<MenuButtons>();
    }
    private void FixedUpdate() 
    {
        if (!isTimeStopped)
        {
            if (mV == 0)
            {
                slowFactor = 0.2f;
                Time.timeScale = slowFactor;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                if (changeProfile)
                {
                    volume.profile = sloMO;
                }
            }
            else
            {
                Time.timeScale = 1f;
                if(changeProfile)
                {
                    volume.profile = main;
                }
            } 
        }
        if (mV != 0 || mH != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
    void Update () 
    {
        mH = joystick.Horizontal * horizontalSpeed;
        mV = joystick.Vertical * speed;
        if (isInverted)
        {
            mV = mV*-1;
            mH = mH*-1f;
        }
        rb.velocity = new Vector3 (mH , 0, mV );

    }

}
