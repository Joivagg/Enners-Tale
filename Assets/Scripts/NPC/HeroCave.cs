using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCave : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject heroDialog;
    [SerializeField]
    private string newText;

    private void Start()
    {
        if(player.GetComponent<EnnerControl>().playerAccess.checkAcademyApproval)
        {
            this.gameObject.GetComponent<Transform>().localPosition -= new Vector3(2, 0, 0);
            heroDialog.GetComponent<DialogInteract>().dialog = newText;
        }
    }
}
