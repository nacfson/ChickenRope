using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearObject : MonoBehaviour
{
    [SerializeField] private GameObject _clearPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GameManager.Instance.SaveClearScene();
            Debug.Log("Clear!!");
            Instantiate(_clearPrefab,collision.gameObject.transform);
            Debug.Log("SpawnedClearPrefab");
        }
    }
}
