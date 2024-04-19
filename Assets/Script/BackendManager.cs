using UnityEngine;
using System.Threading.Tasks; // [����] async ����� �̿��ϱ� ���ؼ��� �ش� namepsace�� �ʿ��մϴ�.  

// �ڳ� SDK namespace �߰�
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
        var bro = Backend.Initialize(true); // �ڳ� �ʱ�ȭ

        // �ڳ� �ʱ�ȭ�� ���� ���䰪
        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 204 Success
        }
        else
        {
            Debug.LogError("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 400�� ���� �߻�
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
            Debug.Log("��й�ȣ�� �ٸ��ϴ�.");
        }
        else
        {
            BackendLogin.Instance.CustomSignUp(inputNewID.text,inputNewPassword.text);
        }
    }



    // =======================================================
    // [�߰�] ���� �Լ��� �񵿱⿡�� ȣ���ϰ� ���ִ� �Լ�(����Ƽ UI ���� �Ұ�)
    // =======================================================
    /*async void Test()
    {
        await Task.Run(() => {
            BackendLogin.Instance.CustomLogin("user1", "1234"); // [�߰�] �ڳ� �α���

            BackendLogin.Instance.UpdateNickname("�г��� ���� �׽�Ʈ"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }*/
}