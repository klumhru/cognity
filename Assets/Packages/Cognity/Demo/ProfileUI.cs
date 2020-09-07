using System.Collections;
using System.Collections.Generic;
using Cognity.Cognito;
using UnityEngine;

namespace Cognity.Demo {
  public class ProfileUI : MonoBehaviour {
    public Profile Profile;
    public Login Login;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnSignOutClick() {
      Login.Signout();
    }
  }
}
