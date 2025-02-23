using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DartBoard : MonoBehaviour
{
    [SerializeField]
    List<BoardPart> partList;

    [SerializeField]
    GameObject textObject;

    [SerializeField]
    int totalPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 2, 0);
    }

    public void UpdateTotalPoints(GameObject obj)
    {
        totalPoint += obj.GetComponent<BoardPart>().point;
        SetTotalPointText(obj);
    }

    void SetTotalPointText(GameObject obj)
    {
        textObject.GetComponent<TextMeshProUGUI>().text = totalPoint.ToString();
    }

}
