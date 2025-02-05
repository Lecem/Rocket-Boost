using UnityEngine;
using DG.Tweening;

public class TweenEducation : MonoBehaviour
{
    public Transform hedefPozisyon;
    public Transform Elevatorr;
    public Transform Küpüsü;
    public Transform SignRed;
    public Transform SignBlue;
    public Ease barrelEase;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           // var targetPos =new Vector3(Elevatorr.position.x,Elevatorr.position.y+30,Elevatorr.position.z);
           //Elevatorr.DOMove(targetPos, 5).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear) ;

           Elevatorr.DOMoveY( 26.4f, 1f ).SetEase(barrelEase);

        }
    }
}
