using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class player1Script : MonoBehaviour
{
    public ParticleSystem effect1;
    public ParticleSystem effect2;
    [SerializeField] Rigidbody rb;
    public float dashCooldown = 7f;
    public float dashCooldownBarF = 10f;
    public float dashDuration = 0.2f;
    public bool useDash;
    public bool canDash = true;
    public bool canRun = true;
    Vector2 controllers;
    Vector2 rotateInput;
    public Rigidbody controlllerPlayer1;
    bool running;
    public float currentStamina = 100;
    public float speed = 3.5f;
    float hitForce = 2f;
    Rigidbody rbBall;
    Vector3 arah;
    public catchBall GetBall;
    public GameObject EmojiActive;
    public GameObject EmojiPlace;
    public Slider slideBarStamina;
    public Slider dashCooDownBar;
    

    void Start()
    {
        if (GetBall == null)
        {
            GetBall = GetComponent<catchBall>();
        }

        rb = GetComponent<player1Script>().GetComponent<Rigidbody>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        controllers = context.ReadValue<Vector2>();
        Debug.Log("control" + controllers);
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        useDash = context.performed;
    }



    public void OnRun(InputAction.CallbackContext context)
    {
        running = context.performed;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(controllers.x, 0f, controllers.y);
        controlllerPlayer1.MovePosition(controlllerPlayer1.position + direction * speed * Time.deltaTime);
        currentStamina = Mathf.Clamp(currentStamina, 0f, 100f);
        slideBarStamina.value = currentStamina;
        dashCooDownBar.value = dashCooldownBarF;
        

        if (direction.magnitude > 0.1f)
        {
            Quaternion rotationss = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationss, 20f * Time.deltaTime);
        }

        if (direction.magnitude > 0.1f)
        {
            Quaternion rotationss = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationss, 20f * Time.deltaTime);
        }

        // PERBAIKAN: Hanya jalankan logika stamina jika canDash true (tidak sedang cooldown)
        if (canDash)
        {
            if (useDash && currentStamina > 0)
            {
                StartCoroutine(processDash());
            }
        }
        

        if (canRun)
        {
            if (running && currentStamina > 0)
            {
                effectPlay();
                speed = GetBall.Catched ? 5f : 7f; // Menggunakan ternary agar lebih ringkas
                currentStamina -= 20f * Time.deltaTime; // Gunakan DeltaTime agar konsisten di semua FPS
            }
            else
            {
                effectStop();
                speed = 3f;
                if (currentStamina < 100) currentStamina += 10f * Time.deltaTime;
            }

            // Cek jika stamina habis total
            if (currentStamina <= 0)
            {
                StartCoroutine(staminaCooldown());
            }
        }
        

        
    }

    IEnumerator staminaCooldown()
    {
        speed = 3f;
        currentStamina = 0;
        canDash = false;
        canRun = false;
        EmojiActive.SetActive(true);
        EmojiPlace.SetActive(true);

        yield return new WaitForSeconds(6);

        running = false;
        speed = 3f;
        currentStamina = 100;
        canDash = true;
        canRun = true;
        EmojiActive.SetActive(false);
        EmojiPlace.SetActive(false);
    }

    IEnumerator processDash()
    {
        canDash = false;
        Vector3 saveVelocity = controlllerPlayer1.linearVelocity;
        controlllerPlayer1.linearVelocity = transform.forward * 40;
        controlllerPlayer1.useGravity = false;
        currentStamina -= 50;
        dashCooldownBarF = 0;
        

        yield return new WaitForSeconds(dashDuration);

        while(dashCooldownBarF <= 7)
        {
            dashCooldownBarF +=  Time.deltaTime;
            controlllerPlayer1.useGravity = true;
            controlllerPlayer1.linearVelocity = saveVelocity;
            yield return null;
            
        }
        dashCooldownBarF = 7;
        canDash = true;
    }

    void effectPlay()
    {
        effect1.Play();
        effect2.Play();   
    }
    void effectStop()
    {
        effect1.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        effect2.Stop(true, ParticleSystemStopBehavior.StopEmitting);   
    }
}
