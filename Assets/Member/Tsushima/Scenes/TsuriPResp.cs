using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsuriPResp : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> point = new List<GameObject>();
    public IEnumerator rePop(int i)
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Set");
        point[i].SetActive(true);
        yield return null;
    }
}
