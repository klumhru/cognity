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
    public string Username;
    public string Password;
    internal Dictionary<string, string> Attributes;
  }
  public class Register : AWSReactiveBehaviour<RegistrationResult> {
    public State State;
    public override void Awake() {
      base.Awake();
    }

    // Start is called before the first frame update
    void Start() {
    }

    public async void SignUp(string username, string password, Dictionary<string, string> attributes) {
      try {
        await State.UserPool.SignUpAsync(username, password, attributes, null).ConfigureAwait(false);
        EnqueueMessage(new RegistrationResult {
          Status = RegistrationResult.RegistrationStatus.Success,
          Username = username,
          Password = password,
          Attributes = attributes
        });
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


