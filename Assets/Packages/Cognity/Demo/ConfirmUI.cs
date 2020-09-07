using System;
using System.Collections;
using System.Collections.Generic;
using Cognity.Cognito;
using TMPro;
using UnityEngine;
namespace Cognity.Demo {

  public class ConfirmUI : MonoBehaviour {
    public TMP_Text Email;
    public TMP_InputField ConfirmationCode;
    public TMP_Text Errors;
    public Confirm Confirm;

    public void ConfirmCode() {
      Confirm.ConfirmCode(Email.text, ConfirmationCode.text);
    }

    public void ResendConfirmCode(string username) {
      Confirm.ResendConfirmCode(username);
    }

    internal void ShowError(string errorMessage) {
      Errors.text = errorMessage;
    }

    internal void Reset(string username) {
      Errors.text = "";
      ConfirmationCode.text = "";
      Email.text = username;
    }
  }
}
