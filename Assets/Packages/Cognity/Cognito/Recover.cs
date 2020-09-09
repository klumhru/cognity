using System;
using System.Collections;
using System.Collections.Generic;
using Amazon.CognitoIdentityProvider.Model;
using UnityEngine;

namespace Cognity.Cognito {

  // Simple container to pass information over threads
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

  // Logic to recover password, by resetting the password
  public class Recover : ObservableBehaviour<RecoverResult> {
    public State State;

    // Start the password recovery process, which sends an email with a code
    // that is entered using the `Confirm` method
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

    // Set a new password for a user, using a code to authorize the password change
    public async void Confirm(string code, string password) {
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
