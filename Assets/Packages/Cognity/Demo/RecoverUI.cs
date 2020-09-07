using System.Collections;
using System.Collections.Generic;
using Cognity.Cognito;
using UnityEngine;

namespace Cognity.Demo {
  public class RecoverUI : MonoBehaviour {
    public Recover Recover;
    public ControllerUI Controller;

    public TMPro.TMP_InputField Username;
    public TMPro.TMP_Text Errors;

    public void SetErrors(string errorMessage) {
      Errors.text = errorMessage;
    }

    public void OnSubmitClick() {
      Recover.RecoverPassword(Username.text);
    }
    public void OnCancelClick() {
      SetErrors(string.Empty);
      Controller.SelectPanel(SelectedPanel.Login);
    }

    public void Reset(string username) {
      Username.text = username;
      Errors.text = "";
    }
  }
}
