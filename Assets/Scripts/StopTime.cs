using UnityEngine;
using System.Collections;
public class StopTime : MonoBehaviour
{
    Cube cube;
    private void Start() 
    {
        cube = GameObject.Find("Player Cube").GetComponent<Cube>();    
    }
    private void OnTriggerEnter(Collider other) 
    {
        cube.isTimeStopped = true;
        StartCoroutine("IStopTime");
    }
    private void OnTriggerExit(Collider other) {
        Destroy(gameObject);
    }
    IEnumerator IStopTime()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        cube.isTimeStopped = false;
        StopCoroutine("StopTime");
    }
}
