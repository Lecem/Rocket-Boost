using System.Drawing;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    //Mathf.PingPong();
    //Vector3.Lerp();
    
    [SerializeField] Vector3 movementVector;
    [SerializeField] float speed;
    Vector3 startPosition ;
    Vector3 endPosition ;
    float movementFactor ;
// [SerializeField]private float aspeed = 2;
// [SerializeField] private float minY = -3f;
// [SerializeField] private float maxY = 30f;
// [SerializeField]private int a=1;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + movementVector;

    }

    private void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f );
        transform.position = Vector3.Lerp(startPosition,endPosition,movementFactor );
    }
    // private void FixedUpdate() {
    //     Vector3 pos = transform.position;
    //     if(a==-1 && pos.y <=minY)
    //     {
    //         a=1;
    //     }else if(a==1 && pos.y>=maxY)
    //     {
    //         a=-1;
    //     }

    //     pos.y +=(Time.fixedDeltaTime * aspeed*a);
    //     transform.position = pos;
    //     Debug.Log(pos);

    // }
     
}
