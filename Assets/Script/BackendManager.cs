using UnityEngine;
using System.Threading.Tasks; // [변경] async 기능을 이용하기 위해서는 해당 namepsace가 필요합니다.  

// 뒤끝 SDK namespace 추가
using BackEnd;
using UnityEngine.UI;
using TMPro;

public class BackendManager : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputPassword;
    public TMP_InputField inputNewID;
    public TMP_InputField inputNewPassword;
    public TMP_InputField inputCheckPassword;
    public TMP_InputField inputNewNickname;


    void Start()
    {
        InitializeBackend();
    }


    private void InitializeBackend()
    {
        var bro = Backend.Initialize(true); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생
        }
    }

    public void ClickLogin()
    {                 
        BackendLogin.Instance.CustomLogin(inputID.text,inputPassword.text);
    }

    public void ClickSignUp()
    {
        if(inputNewPassword.text !=inputCheckPassword.text)
        {
            Debug.Log("비밀번호가 다릅니다.");
        }
        else
        {
            BackendLogin.Instance.CustomSignUp(inputNewID.text,inputNewPassword.text);
        }
    }



    // =======================================================
    // [추가] 동기 함수를 비동기에서 호출하게 해주는 함수(유니티 UI 접근 불가)
    // =======================================================
    /*async void Test()
    {
        await Task.Run(() => {
            BackendLogin.Instance.CustomLogin("user1", "1234"); // [추가] 뒤끝 로그인

            BackendLogin.Instance.UpdateNickname("닉네임 변경 테스트"); // [추가] 닉네임 변겅
            Debug.Log("테스트를 종료합니다.");
        });
    }*/
}