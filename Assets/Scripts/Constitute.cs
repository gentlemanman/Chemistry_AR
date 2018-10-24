using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constitute : MonoBehaviour {

    public GameObject obj;
	public void constituteMolecule()
    {
        Instantiate(obj);
    }
}
