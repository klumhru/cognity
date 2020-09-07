using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cognity.Cognito;

namespace Cognity.Demo {
  public class RegisterUI : MonoBehaviour {
    public ControllerUI Controller;
    public TMP_InputField Username;
    public TMP_InputField Email;
    public TMP_InputField Password;
    public TMP_Text Errors;

    public Register Register;

    void Start() {
    }

    public void ShowError(string message) {
      Errors.text = message;
    }

    public void RegisterClick() {
      Errors.text = string.Empty;
      Register.SignUp(
        Email.text,
        Password.text,
        new Dictionary<string, string>{
          {"email", Email.text},
          {"nickname", Username.text},
        }
      );
    }

    internal void Reset(string username) {
      Errors.text = "";
      Username.text = "";
      Email.text = username;
      Password.text = "";
    }
  }
}
