//* Unity API Login
//*     [IMPORT]
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    //?  [VAR]   -> [START]
    [SerializeField] private TMP_InputField _text_Username;
    [SerializeField] private TMP_InputField _text_Password;
    [SerializeField] private TMP_InputField _text_Error;
    [SerializeField] private string _text_JWT;
    [SerializeField] private string LoginURL = "https://api.kbve.com/api/auth/local/";
    [System.Serializable]   public class UserLoginData  {   public string identifier;   public string password; }

    public Button m_Login, m_Guest, m_CutScene;
    //?  [VAR]   -> [END]

    public void CutScene()
    {
            PlayerData.PlayerEmail = "Guest";
            PlayerData.PlayerJWT = "Guest";
            PlayerData.PlayerUsername = "Guest";
            SceneManager.LoadScene("CutScene", LoadSceneMode.Single);
    }

    public void GuestLogin()
    {
            PlayerData.PlayerEmail = "Guest";
            PlayerData.PlayerJWT = "Guest";
            PlayerData.PlayerUsername = "Guest";
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    public void LoginRequest()  {   StartCoroutine(LoginEnumProcess()); }   // {Coroutine()}
    private IEnumerator LoginEnumProcess() //  [VOID]  -> {LoginEnumProcess()}
    {
        var user = new UserLoginData(); user.identifier = _text_Username.text;  user.password = _text_Password.text;
            
        //* {Request Header}
            string jsonData = JsonUtility.ToJson(user);
            var request = new UnityWebRequest(LoginURL, "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.method = "POST";
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Accept", "application/json");

            yield return request.SendWebRequest();

            //? {y} -> Error
            if(request.result != UnityWebRequest.Result.Success)    { Debug.Log(request.error);  yield break; }
            else {
            //! {y} -> Success  -> #NEXT    -> #WIP

                JSONNode userData = JSON.Parse(request.downloadHandler.text);
                Debug.Log(userData);
                
                PlayerData.PlayerJWT = userData["jwt"];
                PlayerData.PlayerEmail = userData["user"]["email"];
                PlayerData.PlayerUsername = userData["user"]["username"];
                PlayerData.Save();

            //? {y} -> Migrate load to Global Values? 
                Debug.Log(PlayerPrefs.GetString("username"));
                
                
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
                yield break;
            //! Grab the userData , prase, then set the JWT that represents the user.
            //! The JWT might not need any extra levels of security but should expire 30 days.
            //! There will be two arrays that get returned, one with JWT and the other with userData.
            }
        
    }

    //? In theory, after the login is true, we save the JWT and <user> information
    //? Then we use UnityEngine.SceneManagement; to load "IntroMenu"


    void Start  ()  {  
        m_Login.onClick.AddListener(LoginRequest);
        m_Guest.onClick.AddListener(GuestLogin);
        m_CutScene.onClick.AddListener(CutScene);
     }
    void Update ()  {   }
}