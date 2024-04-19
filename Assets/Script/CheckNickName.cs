using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckNickName : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nickNamePopup;
    public TMP_InputField inputNewNickname;
    void Start()
    {
        if (BackendLogin.Instance.CheckNickname()){
            nickNamePopup.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ClickChangeNickName()
    {
        BackendLogin.Instance.UpdateNickname(inputNewNickname.text);
        nickNamePopup.SetActive(false);
    }
}
