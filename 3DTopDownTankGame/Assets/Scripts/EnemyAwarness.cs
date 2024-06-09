using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwarness : MonoBehaviour
{
    [SerializeField] private Material aggresiveMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material = aggresiveMaterial;
        }
    }
}
