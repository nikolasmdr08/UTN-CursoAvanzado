using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoFPS : MonoBehaviour
{
    public float damage = 100f;
    //public Transform efffect;

    RaycastHit hit;
    Ray ray;

    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mira = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        ray = Camera.main.ScreenPointToRay(mira);

        if (Input.GetMouseButtonDown(0)) {
            if(Physics.Raycast(ray, out hit,100f)) {
                Debug.Log(hit.collider.gameObject.name);
                hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
