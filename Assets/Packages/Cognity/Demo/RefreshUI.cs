using System;
using System.Collections;
using System.Collections.Generic;
using Amazon.Extensions.CognitoAuthentication;
using Cognity.Cognito;
using UnityEngine;

namespace Cognity.Demo {
  public class RefreshUI : MonoBehaviour {
    public Refresh Refresh;
    public ControllerUI Controller;
    public State State;
    // Start is called before the first frame update
    void Start() {
      if (string.IsNullOrEmpty(State.RefreshToken) || State.User == null) {
        Controller.SelectPanel(SelectedPanel.Login);
      } else {
        Refresh.RefreshAsync(State.RefreshToken);
      }
    }
  }
}
