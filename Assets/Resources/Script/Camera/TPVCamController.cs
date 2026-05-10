using UnityEngine;
using UnityEngine.InputSystem;

public class TPVCamController : MonoBehaviour
{
    [Header("Target & Posisi")]
    public Transform target; // Masukkan objek Player ke sini via Inspector
    public Vector3 offset = new Vector3(0, 2f, -5f); // Jarak kamera dari player

    [Header("Pengaturan Mouse")]
    public float mouseSensitivity = 0.5f;
    public float verticalMin = -20f; // Biar kamera ga nembus tanah
    public float verticalMax = 60f;  // Biar kamera ga kebalik pas liat atas
    
    private float pitch = 0f; // Rotasi sumbu X (Atas/Bawah)
    private float yaw = 0f;   // Rotasi sumbu Y (Kiri/Kanan)
    private bool isCameraLocked = false;

    void Start()
    {
        // Setup awal kursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Toggle Lock pakai tombol 'C' (sesuaikan dengan selera)
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCameraLocked = !isCameraLocked;
            Cursor.lockState = isCameraLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isCameraLocked;
        }
    }

    // Gunakan LateUpdate untuk kamera agar dieksekusi SETELAH player bergerak
    void LateUpdate()
    {
        if (target == null) return;

        // Baca input mouse hanya jika kamera sedang di-lock
        if (isCameraLocked)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            yaw += mouseDelta.x * mouseSensitivity;
            pitch -= mouseDelta.y * mouseSensitivity;
            
            // Batasi putaran atas bawah
            pitch = Mathf.Clamp(pitch, verticalMin, verticalMax); 
        }

        // Kalkulasi posisi kamera berdasarkan rotasi
        Quaternion currentRotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredPosition = target.position + currentRotation * offset;

        transform.position = desiredPosition;
        
        // Suruh kamera terus menatap player (agak ke atas dikit biar natep badan/kepala, bukan kaki)
        transform.LookAt(target.position + Vector3.up * 1.5f); 
    }
}