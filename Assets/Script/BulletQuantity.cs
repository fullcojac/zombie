using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletQuantity : MonoBehaviour {
    [SerializeField]
    int quantity;
	// Use this for initialization
	public int ReturnQuantity()
    {
        return quantity;
    }
}
