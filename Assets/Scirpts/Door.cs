using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
	void Start ()
    {
        
        mainCharacter = GameObject.Find("MainCharacter");
        mainCharacterLight = mainCharacter.transform.Find("Point light").GetComponent<Light>();
    }
    private GameObject mainCharacter;
    private Light mainCharacterLight;
    public float Range;
    public float mainRange;
	void Update ()
    {
        if (Vector2.Distance(this.gameObject.transform.position, mainCharacter.transform.position) < 60.0f)
        {
            mainCharacterLight.range = Mathf.Lerp(mainCharacterLight.range, Range, .025f);
        }
        else if (Vector2.Distance(this.gameObject.transform.position, mainCharacter.transform.position) > 60.0f)
        {
            mainCharacterLight.range = Mathf.Lerp(mainCharacterLight.range, mainRange, .025f);
        }
    }
}