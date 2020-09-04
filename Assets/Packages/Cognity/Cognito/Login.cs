using UnityEngine;
using System;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using Amazon.CognitoIdentityProvider.Model;

namespace Cognity.Cognito {
  public class Login : AWSReactiveBehaviour<AuthFlowResponse> {
    private AmazonCognitoIdentityProviderClient _provider;
    private CognitoUserPool _userPool;
    private CognitoUser _user;

    public Login Current;

    public override void Awake() {
      base.Awake();
      Current = this;
    }

    // Start is called before the first frame update
    void Start() {
      _provider =
          new AmazonCognitoIdentityProviderClient(new Amazon.Runtime.AnonymousAWSCredentials(),
          RegionEndpoint.GetBySystemName(Configuration.Current.AWS.Region));
      _userPool = new CognitoUserPool(
        Configuration.Current.Cognito.UserPoolId,
        Configuration.Current.Cognito.PlayerUserPoolClientId,
        _provider);
    }

    private void OnResult(AuthFlowResponse res) {
      Debug.Log(res.ToString());
    }

    public async void Authenticate(string username, string password) {
      _user = new CognitoUser(username, Configuration.Current.Cognito.PlayerUserPoolClientId, _userPool, _provider);
      var request = new InitiateSrpAuthRequest() {
        Password = password
      };

      var response = await _user.StartWithSrpAuthAsync(request).ConfigureAwait(false);
      EnqueueMessage(response);
    }
  }
}
