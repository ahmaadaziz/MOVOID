using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public WhenToDissolve whenTo;
    private MeshRenderer meshRenderer;
    private Material[] materials;
    private float t = 0;
    void Start()
    {
        whenTo = GameObject.FindGameObjectWithTag("Dissolve Collider").GetComponent<WhenToDissolve>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    private void Update() 
    {
        if (whenTo.shouldDissolve)
        {
             materials = meshRenderer.materials;
             materials[0].SetFloat("_dissolve",t);
             if (t<1)
             {
                 t += 0.0125f;
             }   
        }
    }
}
