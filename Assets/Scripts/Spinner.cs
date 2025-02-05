using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float rotateX = 0f ;
    [SerializeField] float rotateY = 1f ;
    [SerializeField] float rotateZ = 0f ;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(rotateX, rotateY, rotateZ*Time.deltaTime);
    }
}
