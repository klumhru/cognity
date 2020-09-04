using System;
using System.Collections;
using System.Collections.Generic;
using Cognity.Cognito;
using TMPro;
using UnityEngine;

public class ConfirmUI : MonoBehaviour {
  public TMP_Text Email;
  public TMP_InputField ConfirmationCode;
  public TMP_Text Errors;
  // Start is called before the first frame update
  void Start() {
    Cognity.Cognito.Register.Current.QueuedEvents.AddListener(OnRegisterEvent);
  }

  private void OnRegisterEvent(RegistrationResult res) {
    if (res.Status == RegistrationResult.RegistrationStatus.Success) {
      Email.text = $"Hello, {res.Attributes["email"]}";
    }
  }

  public void Confirm() {

  }
}
