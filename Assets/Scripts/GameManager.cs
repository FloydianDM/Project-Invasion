using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project_Invasion
{
    public class GameManager : MonoBehaviour
    {
        public IEnumerator ReloadLevel()
        {
            GetComponent<PlayerController>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            
            yield return new WaitForSeconds(1);

            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
            
            GetComponent<PlayerController>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}

