using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    
    public void SceneLoad() 
    {
        SceneManager.LoadScene("GameRoom");
    }
}
