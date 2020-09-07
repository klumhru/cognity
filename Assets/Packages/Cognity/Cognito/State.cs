using System;
using System.Collections;
using System.Collections.Generic;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using UnityEngine;

namespace Cognity.Cognito {
  public class State : MonoBehaviour {
    private AmazonCognitoIdentityProviderClient _provider;
    public AmazonCognitoIdentityProviderClient Provider { get => _provider; }
    private CognitoUserPool _userPool;
    public CognitoUserPool UserPool { get => _userPool; }
    private CognitoUser _user;
    public CognitoUser User { get => _user; }
    private RegionEndpoint _endpoint;
    public RegionEndpoint Endpoint { get => _endpoint; }

    const string ACCESS_TOKEN_KEY = "ACCESS_TOKEN_KEY";
    public string AccessToken {
      get => PlayerPrefs.GetString(ACCESS_TOKEN_KEY, "");
      private set => PlayerPrefs.SetString(ACCESS_TOKEN_KEY, value);
    }

    const string ID_TOKEN_KEY = "ID_TOKEN_KEY";
    public string IdToken {
      get => PlayerPrefs.GetString(ID_TOKEN_KEY, "");
      private set => PlayerPrefs.SetString(ID_TOKEN_KEY, value);
    }

    const string REFRESH_TOKEN_KEY = "REFRESH_TOKEN_KEY";
    public string RefreshToken {
      get => PlayerPrefs.GetString(REFRESH_TOKEN_KEY, "");
      private set => PlayerPrefs.SetString(REFRESH_TOKEN_KEY, value);
    }

    const string USERNAME_KEY = "USERNAME_KEY";
    public string Username {
      get => PlayerPrefs.GetString(USERNAME_KEY, "");
      private set => PlayerPrefs.SetString(USERNAME_KEY, value);
    }

    private CognitoAWSCredentials AWSCredentials;
    public Login Login;
    public Refresh Refresh;
    public Confirm Confirm;
    public Register Register;

    void Awake() {
      _endpoint = RegionEndpoint.GetBySystemName(Configuration.Current.AWS.Region);
      _provider =
          new AmazonCognitoIdentityProviderClient(new Amazon.Runtime.AnonymousAWSCredentials(),
          _endpoint);
      _userPool = new CognitoUserPool(
        Configuration.Current.Cognito.UserPoolId,
        Configuration.Current.Cognito.PlayerUserPoolClientId,
        _provider);
      if (!string.IsNullOrEmpty(Username)) {
        SetUser(Username);
      }
    }

    public void SetUser(string username) {
      _user = new CognitoUser(Username = username, Configuration.Current.Cognito.PlayerUserPoolClientId, _userPool, _provider) {
        SessionTokens = new CognitoUserSession(
          IdToken, AccessToken, RefreshToken, DateTime.Now, DateTime.Now.AddHours(1)
        )
      };
    }
    // Start is called before the first frame update
    void Start() {
      Login.QueuedEvents.AddListener(HandleLoginEvent);
      Refresh.QueuedEvents.AddListener(HandleRefreshEvent);
      Confirm.QueuedEvents.AddListener(HandleConfirmEvent);
      Register.QueuedEvents.AddListener(HandleRegisterEvent);
    }

    private void HandleRegisterEvent(RegistrationResult res) {
      ResetState();
      switch (res.Status) {
        case RegistrationResult.RegistrationStatus.Error:
          break;
        case RegistrationResult.RegistrationStatus.Success:
          Username = res.Username;
          break;
      }
    }

    private void ResetState() {
      Username = "";
      IdToken = "";
      AccessToken = "";
      RefreshToken = "";
    }

    private void HandleConfirmEvent(ConfirmResult res) {
      if (res.Status == ConfirmResult.ConfirmStatus.Success) {

      }
    }

    private void HandleRefreshEvent(RefreshResult res) {
      if (res.Status == RefreshResult.RefreshStatus.Success) {
        AccessToken = res.Response.AuthenticationResult.AccessToken;
        IdToken = res.Response.AuthenticationResult.IdToken;
      }
    }

    private void HandleLoginEvent(LoginResult res) {
      switch (res.Status) {
        case LoginResult.LoginStatus.Success:
          AccessToken = res.Response.AuthenticationResult.AccessToken;
          IdToken = res.Response.AuthenticationResult.IdToken;
          RefreshToken = res.Response.AuthenticationResult.RefreshToken;
          Username = res.Username;
          AWSCredentials = res.Credentials;
          break;
        case LoginResult.LoginStatus.SignedOut:
          ResetState();
          break;
      }
    }
  }
}
