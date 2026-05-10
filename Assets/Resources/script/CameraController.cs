using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [Header("Targets")]
    public Transform player1;
    public Transform player2;
    public Transform ball;
    public Camera cam;

    [Header("Weights (total tidak harus = 1)")]
    [Range(0f, 1f)] public float playerWeight = 0.75f;  // per player
    [Range(0f, 2f)] public float ballWeight = 1.5f;   // bola lebih dominan

    [Header("Follow Settings")]
    public float lerpSpeed = 6f;
    public Vector3 cameraOffset = new Vector3(0, 8f, -2f); // top-down + slight tilt
    public float tiltAngle = 60f; // derajat dari horizontal (75 = almost top-down)

    [Header("Zoom (Height)")]
    public float minHeight = 10f;
    public float maxHeight = 60f;
    public float zoomPadding = 5f;
    public float zoomLerpSpeed = 4f;

    [Header("Depth of Field")]
    public bool enableDof = true;
    [Range(0f, 5f)] public float dofLerpSpeed = 3f;

    // DoF component (assign jika pakai Post Processing)
    // public UnityEngine.Rendering.Universal.DepthOfField dofVolume;

    private Vector3 _targetPos;
    private float _targetHeight;

    void LateUpdate()  // LateUpdate biar jalan setelah semua physics
    {
        if (player1 == null || player2 == null || ball == null) return;

        // === 1. WEIGHTED MIDPOINT ===
        float totalWeight = playerWeight * 2 + ballWeight;

        Vector3 weightedCenter =
            (player1.position * playerWeight +
             player2.position * playerWeight +
             ball.position * ballWeight) / totalWeight;

        // Hanya ambil X dan Z (horizontal plane)
        Vector3 targetXZ = new Vector3(weightedCenter.x, 0f, weightedCenter.z);

        // === 2. AUTO ZOOM dari bounding box semua objek ===
        if (zoomPadding > 0)
        {
            float targetH = GetTargetHeight();
            _targetHeight = Mathf.Lerp(_targetHeight, targetH, Time.deltaTime * zoomLerpSpeed);
        }

        // === POSITION: lerp ke target ===
        Vector3 desiredPos = targetXZ + new Vector3(0, _targetHeight, -_targetHeight / Mathf.Tan(tiltAngle * Mathf.Deg2Rad));
        cam.transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * lerpSpeed);

        // === ROTATION: FIXED ===
        cam.transform.rotation = Quaternion.Euler(tiltAngle, 0f, 0f);

        // === 5. DOF � focus ke bola (bukan midpoint) ===
        if (enableDof) UpdateDof();
    }

    float GetTargetHeight()
    {
        // Bounding box dari semua 3 objek
        float minX = Mathf.Min(player1.position.x, player2.position.x, ball.position.x);
        float maxX = Mathf.Max(player1.position.x, player2.position.x, ball.position.x);
        float minZ = Mathf.Min(player1.position.z, player2.position.z, ball.position.z);
        float maxZ = Mathf.Max(player1.position.z, player2.position.z, ball.position.z);

        float spanX = (maxX - minX) + zoomPadding;
        float spanZ = (maxZ - minZ) + zoomPadding;
        float span = Mathf.Max(spanX, spanZ);

        // Height proporsional dari span
        float h = span * 0.8f;  // tuning factor
        return Mathf.Clamp(h, minHeight, maxHeight);
    }

    void UpdateDof()
    {
        // Kalau pakai URP Post Processing Volume:
        // float dist = Vector3.Distance(transform.position, ball.position);
        // dofVolume.focusDistance.value = Mathf.Lerp(dofVolume.focusDistance.value, dist, Time.deltaTime * dofLerpSpeed);

        // Alternatif: pakai built-in Camera.focusDistance (jika ada lens shift)
        // Atau manual lewat shader property
    }

    // Gizmo buat debug di Scene view
    void OnDrawGizmos()
    {
        if (player1 == null || player2 == null || ball == null) return;

        float total = playerWeight * 2 + ballWeight;
        Vector3 mid = (player1.position * playerWeight +
                       player2.position * playerWeight +
                       ball.position * ballWeight) / total;

        // Weighted center = kuning
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector3(mid.x, 0, mid.z), 0.4f);

        // Lines ke tiap target
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(mid, player1.position);
        Gizmos.DrawLine(mid, player2.position);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(mid, ball.position);  // bola = merah, lebih dominan

        // Bounding box
        Gizmos.color = new Color(1, 1, 0, 0.2f);
        float minX = Mathf.Min(player1.position.x, player2.position.x, ball.position.x);
        float maxX = Mathf.Max(player1.position.x, player2.position.x, ball.position.x);
        float minZ = Mathf.Min(player1.position.z, player2.position.z, ball.position.z);
        float maxZ = Mathf.Max(player1.position.z, player2.position.z, ball.position.z);
        Vector3 boxCenter = new Vector3((minX + maxX) / 2, 0, (minZ + maxZ) / 2);
        Vector3 boxSize = new Vector3(maxX - minX + zoomPadding, 0.1f, maxZ - minZ + zoomPadding);
        Gizmos.DrawCube(boxCenter, boxSize);
    }
}
