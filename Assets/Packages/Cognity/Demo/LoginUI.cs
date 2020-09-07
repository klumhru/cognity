using System;
using System.Collections;
using System.Collections.Generic;
using Amazon.Extensions.CognitoAuthentication;
using Cognity.Cognito;
using TMPro;
using UnityEngine;

namespace Cognity.Demo {
  public class LoginUI : MonoBehaviour {
    public TMP_InputField Username;
    public TMP_InputField Password;
    public TMP_Text Errors;
    public Login Login;
    // Start is called before the first frame update
    void Start() { }

    public void Authenticate() {
      ShowError(string.Empty);
      Login.Authenticate(Username.text, Password.text);
    }

    internal void ShowError(string errorMessage) {
      Errors.text = errorMessage;
    }

    internal void Reset(string username) {
      Username.text = username;
      Password.text = "";
      Errors.text = "";
    }
  }
}
