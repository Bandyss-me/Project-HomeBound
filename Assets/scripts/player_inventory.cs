using UnityEngine;
using UnityEngine.UI;

public class player_inventory : MonoBehaviour
{
    [SerializeField]
    Transform left_arm,right_arm;
    [SerializeField]
    Image rightI,leftI;

    void Update(){
        if(left_arm.childCount>0 && left_arm.GetChild(0).gameObject){
            leftI.gameObject.SetActive(true);
        }
        else{
            leftI.gameObject.SetActive(false);
        }
        if(right_arm.childCount>0 && right_arm.GetChild(0).gameObject){
            rightI.gameObject.SetActive(true);
        }
        else{
            rightI.gameObject.SetActive(false);
        }
    }
}
