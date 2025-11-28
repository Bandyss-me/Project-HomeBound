using UnityEngine;

public class player_buy_script : MonoBehaviour
{
    [SerializeField]
    Transform MainCamera;
    [SerializeField]
    float pickup_range;

    void Update(){
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            Buy();
        }
    }

    void Buy(){
        RaycastHit hit;
        if(Physics.Raycast(MainCamera.position, MainCamera.forward, out hit, pickup_range)){
            if(hit.collider.gameObject.GetComponent<Item_SaveMyData>()==null)
                hit.collider.gameObject.AddComponent<Item_SaveMyData>();
        }
    }
}
