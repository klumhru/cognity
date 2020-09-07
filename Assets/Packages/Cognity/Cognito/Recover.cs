using System;
using System.Collections;
using System.Collections.Generic;
using Amazon.CognitoIdentityProvider.Model;
using UnityEngine;

namespace Cognity.Cognito {
  public struct RecoverResult {
    public enum RecoverStatus {
      Confirm,
      Error,
      Success,
    }
    public RecoverStatus Status;
    public Exception InnerException;
    public string ErrorMessage;
    public string Username;
  }
  public class Recover : AWSReactiveBehaviour<RecoverResult> {
    public State State;
    public override void Awake() {
      base.Awake();
    }

    public async void RecoverPassword(string username) {
      try {
        State.SetUser(username);
        await State.User.ForgotPasswordAsync().ConfigureAwait(false);
        EnqueueMessage(new RecoverResult {
          Status = RecoverResult.RecoverStatus.Confirm,
          Username = username
        });
      } catch (Exception ex) {
        EnqueueMessage(new RecoverResult {
          Status = RecoverResult.RecoverStatus.Error,
          ErrorMessage = ex.Message,
          InnerException = ex
        });
      }
    }

    internal async void Confirm(string code, string password) {
      try {
        await State.User.ConfirmForgotPasswordAsync(code, password).ConfigureAwait(false);
        EnqueueMessage(new RecoverResult {
          Status = RecoverResult.RecoverStatus.Success,
        });
      } catch (Exception ex) {
        EnqueueMessage(new RecoverResult {
          Status = RecoverResult.RecoverStatus.Error,
          ErrorMessage = ex.Message,
          InnerException = ex
        });
      }
    }
  }
}
