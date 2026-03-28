using UnityEngine;
using UnityEngine.UI;

public class openingStartScript : MonoBehaviour
{
    public SpawnManager spawn;
    public GameObject blueTEAMUI;
    public GameObject redTEAMUI;
    public Animator closingTEAM;
    public GameObject BLOCKS;


    void Start()
    {
        spawn.GetComponent<SpawnManager>();
        BLOCKS.SetActive(true);
        
    }

    void Update()
    {
        if (spawn.p1Spawned == true)
        {
            redTEAMUI.GetComponent<Image>().color = Color.red;
        }
        if(spawn.p2Spawned == true)
        {
            blueTEAMUI.GetComponent<Image>().color = Color.blue;
        }         
        if (spawn.p1Spawned == true && spawn.p2Spawned == true)
        {
            closingTEAM.SetTrigger("on");
        }
    
        
    }
}
