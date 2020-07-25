using UnityEngine;
public class SpawnLevel : MonoBehaviour
{
    private bool finishedLevels;
    private GameObject playerCube;
    private GameObject currentLvl;
    private Cube cube;
    public GameObject[] Levels;
    private float currentLvlPos;
    private float nextLvlPos;
    private Vector3 spawnPos;
    private void Start() 
    {
        playerCube = GameObject.Find("Player Cube");
        cube = playerCube.GetComponent<Cube>();
        finishedLevels = false;
    }
    private void OnTriggerExit(Collider other) 
    {
         SpawnNxtLvl(cube.i);
         if (cube.i == 17)
         {
             finishedLevels = true;
         }
         if (finishedLevels)
         {
             cube.i = Random.Range(5,17);
         }
         else if(!finishedLevels)
         {
             cube.i++;
         }
         cube.incPosBy = cube.incPosBy + 82f;
         Debug.Log("Increment");
         Destroy(gameObject);
    }
    private void SpawnNxtLvl(int index)
    {
        currentLvlPos = Levels[index].transform.position.z;
        nextLvlPos = currentLvlPos + cube.incPosBy;
        spawnPos = new Vector3(8.533161f, 5.552793f, nextLvlPos);
        Instantiate(Levels[index],spawnPos,Quaternion.identity);
    }
}
