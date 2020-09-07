using System.Collections;
using System.Collections.Generic;
using Cognity.Cognito;
using UnityEngine;

namespace Cognity.Demo {
  public class ProfileUI : MonoBehaviour {
    public Profile Profile;
    public Login Login;

    public void OnSignOutClick() {
      Login.Signout();
    }
  }
}
