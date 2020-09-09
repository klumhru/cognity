using UnityEngine;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime.Internal;
using System;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.CognitoIdentity;

namespace Cognity.Cognito {

  // A simple container to pass result to observers
  public struct LoginResult {
    public enum LoginStatus {
      Success,
      Error,
      Unconfirmed,
      SignedOut
    }
    public AuthFlowResponse Response;
    public LoginStatus Status;
    public string ErrorMessage;
    public Exception InnerException;
    public InitiateSrpAuthRequest Request;
    public string Username;
    internal CognitoAWSCredentials Credentials;
  }

  // Authentication manager
  public class Login : ObservableBehaviour<LoginResult> {
    public State State;

    public async void Authenticate(string username, string password) {
      State.SetUser(username);
      var request = new InitiateSrpAuthRequest() {
        Password = password
      };
      try {
        var response = await State.User.StartWithSrpAuthAsync(request).ConfigureAwait(false);
        var credentials = State.User.GetCognitoAWSCredentials(State.UserPool.PoolID, State.Endpoint);
        EnqueueMessage(new LoginResult {
          Response = response,
          Status = LoginResult.LoginStatus.Success,
          Username = username,
          Credentials = credentials
        });
      } catch (HttpErrorResponseException ex) {
        EnqueueMessage(new LoginResult {
          InnerException = ex,
          ErrorMessage = ex.Message,
          Status = LoginResult.LoginStatus.Error
        });
      } catch (UserNotConfirmedException ex) {
        EnqueueMessage(new LoginResult {
          Request = request,
          Username = username,
          InnerException = ex,
          ErrorMessage = ex.Message,
          Status = LoginResult.LoginStatus.Unconfirmed,
        });
      } catch (Exception ex) {
        EnqueueMessage(new LoginResult {
          InnerException = ex,
          ErrorMessage = ex.Message,
          Status = LoginResult.LoginStatus.Error
        });
      }
    }

    public void Signout() {
      try {
        State.User.SignOut();
        EnqueueMessage(new LoginResult {
          Status = LoginResult.LoginStatus.SignedOut,
        });
      } catch (Exception ex) {
        EnqueueMessage(new LoginResult {
          Status = LoginResult.LoginStatus.Error,
          InnerException = ex,
          ErrorMessage = ex.Message
        });
      }
    }
  }
}
