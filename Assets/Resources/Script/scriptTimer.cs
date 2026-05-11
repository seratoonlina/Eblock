using TMPro;
using UnityEngine;
using System; // Tambahkan ini agar Math.Floor bisa terbaca

public class scriptTimer : MonoBehaviour
{
    TextMeshProUGUI timeGUI;
    public bool onORoffTIME;
    public float totalSecs; // 1800 detik = 30 menit
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
            if (totalSecs > 0)
            {
                // 1. Kurangi waktu berdasarkan waktu nyata (detik)
                totalSecs -= Time.deltaTime;

                // 2. Cegah waktu menjadi minus
                if (totalSecs < 0) totalSecs = 0;

                // 3. Hitung menit dan detik
                int minutes = Mathf.FloorToInt(totalSecs / 60);
                int seconds = Mathf.FloorToInt(totalSecs % 60);

                // 4. Masukkan ke dalam format string dan tampilkan ke UI
                timeGUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
            totalSecs -= 0;
        }
    }
}