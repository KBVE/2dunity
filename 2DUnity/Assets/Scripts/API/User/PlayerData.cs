using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour {
   public static string PlayerUsername {
        get {   return PlayerPrefs.GetString("PlayerUsername", "Guest");   }
        set {   PlayerPrefs.SetString("PlayerUsername", value);   }
    }

    public static string PlayerJWT {
        get {   return PlayerPrefs.GetString("PlayerJWT", "Guest");   }
        set {   PlayerPrefs.SetString("PlayerJWT", value);   }
    }

    public static string PlayerEmail {
        get {   return PlayerPrefs.GetString("PlayerEmail", "Guest");   }
        set {   PlayerPrefs.SetString("PlayerEmail", value);   }
    }

    public static void Save() {
        PlayerPrefs.Save();
    }
}