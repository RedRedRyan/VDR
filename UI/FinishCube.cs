using UnityEngine;
using UnityEngine.SceneManagement;   
using System.Collections.Generic;
using System.Collections;
public class FinishCube : MonoBehaviour
{
    public bool isPassCondition = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResultSystem resultSystem = FindObjectOfType<ResultSystem>();
            if (resultSystem != null)
            {
                resultSystem.ShowResult(isPassCondition);
            }
        }
    }
}