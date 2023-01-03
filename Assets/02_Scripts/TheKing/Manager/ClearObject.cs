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
            GameManager.Instance.SaveClearScene();
            Vector2 transform = new Vector2(collision.transform.position.x, collision.transform.position.y - 0.5f);
            GameObject obj = Instantiate(_clearPrefab,collision.gameObject.transform);
            obj.transform.position = transform;
            GameManager.Instance.ClearAction?.Invoke();
        }
    }
}
