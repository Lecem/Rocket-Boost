using UnityEngine;
using DG.Tweening;

public class TweenEducation : MonoBehaviour
{
    public Transform hedefPozisyon, Elevatorr, Küpüsü, SignRed, SignBlue ;
    public Ease barrelEase; //bunu ekleyerek 


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           // var targetPos =new Vector3(Elevatorr.position.x,Elevatorr.position.y+30,Elevatorr.position.z);
           //Elevatorr.DOMove(targetPos, 5).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear) ;

           Elevatorr.DOMoveY( 26f, 5f ).SetEase(barrelEase);

        }
    }
}
