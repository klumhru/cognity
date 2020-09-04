using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cognity.Cognito;

public class RegisterUI : MonoBehaviour {
  public TMP_InputField Username;
  public TMP_InputField Email;
  public TMP_InputField Password;
  public TMP_Text Errors;
  // Start is called before the first frame update
  void Start() {
    Cognity.Cognito.Register.Current.QueuedEvents.AddListener(OnRegisterEvent);
  }

  void OnRegisterEvent(RegistrationResult res) {
    Errors.text = string.Empty;

    switch (res.Status) {
      case RegistrationResult.RegistrationStatus.Error:
        Errors.text = res.ErrorMessage;
        break;
    }
  }

  public void Register() {
    Cognity.Cognito.Register.Current.SignUp(
      Email.text,
      Password.text,
      new Dictionary<string, string>{
        {"email", Email.text},
        {"nickname", Username.text},
      }
    );
  }

  // Update is called once per frame
  void Update() {

  }
}
