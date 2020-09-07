using System.Collections;
using System.Collections.Generic;
using Cognity.Cognito;
using UnityEngine;
using TMPro;

namespace Cognity.Demo {
  public class RecoverConfirmUI : MonoBehaviour {
    public Recover Recover;
    public ControllerUI Controller;

    public TMP_Text Email;
    public TMP_InputField Code;
    public TMP_InputField Password;
    public TMP_Text Errors;


    public void Reset(string email) {
      Errors.text = "";
      Code.text = "";
      Password.text = "";
      Email.text = $"Email: {email}";
    }

    public void SetErrors(string errorMessage) {
      Errors.text = errorMessage;
    }

    public void OnSubmitClick() {
      Recover.Confirm(Code.text, Password.text);
    }
    public void OnCancelClick() {
      Controller.RecoverCancel();
    }
  }
}
