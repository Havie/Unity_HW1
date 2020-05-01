using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{

    public Interacter inter;
    public BatteryCollect bc;
    // Start is called before the first frame update
    void Start()
    {
        inter = this.GetComponent<Interacter>();
        bc = GameObject.FindGameObjectWithTag("BatteryUI").GetComponent<BatteryCollect>();
    }

    private void OnMouseDown()
    {
        if (inter.withinRange())
        {
            bc.increaseJuice(1);
            Destroy(this.gameObject);
            Audioplayer.Instance.PlayInventory();
        }
    }
}
