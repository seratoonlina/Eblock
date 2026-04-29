using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class cameraANIM : MonoBehaviour
{
    [SerializeField] float scoreRed;
    [SerializeField] float scoreBlue;
    public GameObject enableGAMEPAD;
    public GameObject players;
    public GameObject blue;
    public GameObject red;
    public GameObject green;


    void Start()
    {
        enableGAMEPAD.SetActive(false);
        scoreBlue = PlayerPrefs.GetFloat("blueScore", 0f);
        scoreRed = PlayerPrefs.GetFloat("redScore", 0f);
        if (scoreRed > scoreBlue)
        {
            players.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (scoreRed < scoreBlue)
        {
            players.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    
    
    public void startAnimationobject()
    {
        players.GetComponent<Animator>().SetTrigger("on");
        enableGAMEPAD.SetActive(true);
        green.SetActive(true);
        green.GetComponent<Animator>().SetTrigger("on");
        if (scoreRed > scoreBlue)
        {
            red.SetActive(true);
            blue.SetActive(false);
            red.GetComponent<Animator>().SetTrigger("on");
        }
        if (scoreRed < scoreBlue)
        {
            red.SetActive(false);
            blue.SetActive(true);
            blue.GetComponent<Animator>().SetTrigger("on");
        }
    }

}
