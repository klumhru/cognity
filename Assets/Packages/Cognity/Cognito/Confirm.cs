using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using UnityEngine;

public class Confirm : MonoBehaviour {
  private AmazonCognitoIdentityProviderClient _provider;
  private CognitoUserPool _userPool;
  private CognitoUser _user;

  public static Confirm Current;

  void Awake() {
    Current = this;
  }
}
