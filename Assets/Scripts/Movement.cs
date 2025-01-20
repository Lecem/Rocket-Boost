using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    //PARAMETERS - for tuning, typically set in the editor

    //CACHE - eg. references for readability or speed 

    //STATE - private instances (member) variables

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrenght = 100f;
    [SerializeField] float rotationStrenght = 10f;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
       
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

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();

    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed()) 
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }
    
    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSFX);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
    
    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        //Debug.Log("Obje kaç kez döndürüldü:"+ rotationInput); //ihtiyaç olmadığı için kaldırdık
        if (rotationInput < 0) //Sol
        {
            RotateLeft();
        }
        else if (rotationInput > 0) //Sag
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }
    
    private void RotateLeft()
    {
        //transform.Rotate(0f, 0f, 1f); //bunu yazmanın diğer yolu alt satırda
        //transform.Rotate(Vector3.forward * rotationStrenght * Time.fixedDeltaTime);
        ApplyRotation(rotationStrenght);
        if (!rightThrustParticles.isPlaying)
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Play();
        }
    }
    
    private void RotateRight()
    {
        ApplyRotation(-rotationStrenght);
        if (!leftThrustParticles.isPlaying)
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Play();
        }
    }
    
    private void StopRotating()
    {
        leftThrustParticles.Stop();
        rightThrustParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
