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