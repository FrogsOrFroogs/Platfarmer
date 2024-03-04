using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestActivator : MonoBehaviour
{
    public int chestSize = 12;
    public int hotbarSize = 6;
    [SerializeField] ChestPage chestScript;

    void Start()
    {
        chestScript.InitializeUI(chestSize, hotbarSize);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            chestScript.Hide();
        }
    }

    public void ChangeState()
    {
        if(chestScript.isActiveAndEnabled == true)
        {
            chestScript.Hide();
        }else{
            chestScript.Show();
        }
    }
}
