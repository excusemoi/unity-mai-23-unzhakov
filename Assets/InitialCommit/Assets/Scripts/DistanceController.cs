using UnityEngine;

public class DistanceController : MonoBehaviour
{
    public GameObject A;
    private Renderer _rendererA;
    public GameObject B;
    private Renderer _rendererB;

    private void Awake()
    { 
        _rendererA = A.GetComponent<Renderer>();
        _rendererB = B.GetComponent<Renderer>();
    }
    
    void Update()
    {
        if (A is null || B is null)
        {
            return;
        }
        // works properly for circles objects only :)
        float centersDistance = Vector3.Distance(A.transform.position, B.transform.position);
        Bounds boundsA = _rendererA.bounds;
        Bounds boundsB = _rendererB.bounds;
        float rA = Mathf.Min(boundsA.extents.x, boundsA.extents.y);
        float rB = Mathf.Min(boundsB.extents.x, boundsB.extents.y);
        if (centersDistance <= rA + rB && _rendererB.enabled)
        {
            A.SetActive(false);
        }
    }
}
