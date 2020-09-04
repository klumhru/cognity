using System;
using System.Collections.Generic;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime.Internal;

namespace Cognity.Cognito {
  public struct RegistrationResult {
    public enum RegistrationStatus {
      Error,
      Success,
    }
    public RegistrationStatus Status;
    public string ErrorMessage;
    public Exception InnerException;
    internal Dictionary<string, string> Attributes;
  }
  public class Register : AWSReactiveBehaviour<RegistrationResult> {
    private AmazonCognitoIdentityProviderClient _provider;
    private CognitoUserPool _userPool;
    private CognitoUser _user;

    public static Register Current;
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

    public async void SignUp(string username, string password, Dictionary<string, string> attributes) {
      try {
        await _userPool.SignUpAsync(username, password, attributes, null).ConfigureAwait(false);
      } catch (HttpErrorResponseException ex) {
        EnqueueMessage(new RegistrationResult {
          Status = RegistrationResult.RegistrationStatus.Error,
          ErrorMessage = ex.Message,
          InnerException = ex
        });
      } catch (Exception ex) {
        EnqueueMessage(new RegistrationResult {
          Status = RegistrationResult.RegistrationStatus.Error,
          ErrorMessage = ex.Message,
          InnerException = ex,
          Attributes = attributes
        });
      }
    }
  }
}


