using System;
using System.Collections;
using System.Collections.Generic;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using UnityEngine;

namespace Cognity.Cognito {

  // Simple container to pass information over threads
  public struct RefreshResult {
    public enum RefreshStatus {
      Success,
      Error,
    }
    public Exception InnerException;
    public string ErrorMessage;
    public AuthFlowResponse Response;
    public RefreshStatus Status;
  }
  public class Refresh : ObservableBehaviour<RefreshResult> {
    public State State;
    public Login Login;

    // Refresh the authentication tokens (JWT), using the stored refresh token
    public async void RefreshAsync(string refreshToken) {
      var request = new InitiateRefreshTokenAuthRequest {
        AuthFlowType = AuthFlowType.REFRESH_TOKEN
      };
      try {
        var response = await State.User.StartWithRefreshTokenAuthAsync(request);
        EnqueueMessage(new RefreshResult {
          Response = response,
          Status = RefreshResult.RefreshStatus.Success
        });
      } catch (Exception ex) {
        EnqueueMessage(new RefreshResult {
          Status = RefreshResult.RefreshStatus.Error,
          InnerException = ex,
          ErrorMessage = ex.Message
        });
      }
    }
  }
}
