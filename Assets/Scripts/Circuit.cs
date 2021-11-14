using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Circuit : MonoBehaviour
{
    [SerializeField]
    private bool hasLeft, hasTop, hasRight, hasBottom;

    private bool left, top, right, bottom ;

    [SerializeField]
    GameObject[] showPowered, hidePowered;

    [SerializeField]
    private bool powered = false;
    // Start is called before the first frame update
    void Awake()
    {
        left = hasLeft;
        right = hasRight;
        bottom = hasBottom;
        top = hasTop;
        
    }

    void Start()
    {
       Rotate();
       Rotate();
       Rotate();
       Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate()
    {
        print("rote");
        bool tempLeft = left, tempRight = right, tempTop = top, tempBottom = bottom;
        top = tempLeft;
        right = tempTop;
        bottom = tempRight;
        left = tempBottom;
        UpdateCircuit();

        transform.parent.GetComponent<CircuitController>().UpdatePower();
    }

    void UpdateCircuit()
    {
        transform.Find("edges").Find("left").gameObject.SetActive(left);
        transform.Find("edges").Find("right").gameObject.SetActive(right);
        transform.Find("edges").Find("bottom").gameObject.SetActive(bottom);
        transform.Find("edges").Find("top").gameObject.SetActive(top);

        transform.Find("edges").Find("left").GetComponent<Image>().color = GetColor();
        transform.Find("edges").Find("right").GetComponent<Image>().color = GetColor();
        transform.Find("edges").Find("top").GetComponent<Image>().color = GetColor();
        transform.Find("edges").Find("bottom").GetComponent<Image>().color = GetColor();


        foreach(GameObject g in showPowered) g.SetActive(powered);
        foreach(GameObject g in hidePowered) g.SetActive(!powered);
        
    }

    Color GetColor()
    {
        return powered ? Color.yellow : Color.gray;
    }

    public bool HasPower()
    {
        return powered;
    }

    public void SetPower(bool b)
    {
        powered = b;
        UpdateCircuit();
    }

    public (bool, bool, bool, bool) GetDirections()
    {
        return (left, top, right, bottom);
    }
}
