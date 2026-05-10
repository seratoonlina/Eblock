using TMPro;
using UnityEngine;
using System; // Tambahkan ini agar Math.Floor bisa terbaca

public class scriptTimer : MonoBehaviour
{
    TextMeshProUGUI timeGUI;
    public bool onORoffTIME;
    public float totalDetik; // 1800 detik = 30 menit
    public GameObject TIMESUP;
    public GameObject ballEND;

    void Start()
    {
        timeGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (onORoffTIME == true)
        {
            if (totalDetik > 0)
            {
                // 1. Kurangi waktu berdasarkan waktu nyata (detik)
                totalDetik -= Time.deltaTime;

                // 2. Cegah waktu menjadi minus
                if (totalDetik < 0) totalDetik = 0;

                // 3. Hitung menit dan detik
                int menit = Mathf.FloorToInt(totalDetik / 60);
                int detik = Mathf.FloorToInt(totalDetik % 60);

                // 4. Masukkan ke dalam format string dan tampilkan ke UI
                timeGUI.text = string.Format("{0:00}:{1:00}", menit, detik);
            }
            else
            {
                // Apa yang terjadi kalau waktu habis?
                timeGUI.text = "00:00";
                Debug.Log("Waktu Habis!");
                ballEND.SetActive(false);
                TIMESUP.SetActive(true);
                TIMESUP.GetComponent<Animator>().SetTrigger("on");
            }
        }

        if (onORoffTIME == false)
        {
            totalDetik -= 0;
        }
    }
}