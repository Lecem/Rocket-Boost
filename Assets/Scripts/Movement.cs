using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrenght = 100f;
    [SerializeField] float rotationStrenght = 10f;
   

    Rigidbody rb;
    AudioSource audioSource;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>(); //burada da rb ye rigidbody olduğunu söyledik
        audioSource = GetComponent<AudioSource>();

    }

     private void OnEnable()//obje aktif olduğu anda çalışır
    {
        thrust.Enable();  
        rotation.Enable(); //burada etkinleştiriyoruz sanırım? aynen.      
    }

     void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();

    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed() == true) //parantez içine sadece thrust.IsPressed() yazılırsa da olur
        {
            //Debug.Log("Hoppidik Hoppidik"); //artık ihtiyacımız olmadığı için kaldırdık
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }    
        }

        else
        {
          audioSource.Stop(); 
        }

    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        //Debug.Log("Obje kaç kez döndürüldü:"+ rotationInput); //ihtiyaç olmadığı için kaldırdık
        
        if(rotationInput < 0 )
        {
            //transform.Rotate(0f, 0f, 1f); //bunu yazmanın diğer yolu alt satırda
            //transform.Rotate(Vector3.forward * rotationStrenght * Time.fixedDeltaTime);
            ApplyRotation(rotationStrenght);
        }

        else if (rotationInput > 0 )
        {
            ApplyRotation(-rotationStrenght);

        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;

        
    }

    






}
