using System;

namespace Cognity.Cognito {

  // A simple container to pass result to observers
  public struct ConfirmResult {
    public enum ConfirmStatus {
      Success,
      Error,
      Resent
    }
    public ConfirmStatus Status;
    public string ErrorMessage;
    public Exception InnerException;
    public string Username;
  }

  // Registration confirmation logic
  public class Confirm : ObservableBehaviour<ConfirmResult> {
    public State State;

    // Confirm registration for a user with a code from the generic email
    public void ConfirmCode(string username, string code) {
      State.SetUser(username);
      try {
        State.User.ConfirmSignUpAsync(code, false).ConfigureAwait(false);
        EnqueueMessage(new ConfirmResult {
          Status = ConfirmResult.ConfirmStatus.Success,
          Username = username,
        });
      } catch (Exception ex) {
        EnqueueMessage(new ConfirmResult {
          Status = ConfirmResult.ConfirmStatus.Error,
          ErrorMessage = ex.Message,
          InnerException = ex,
          Username = username
        });
      }
    }

    // Create and send a new confirmation code for a user
    internal async void ResendConfirmCode(string username) {
      State.SetUser(username);
      try {
        await State.User.ResendConfirmationCodeAsync().ConfigureAwait(false);
        EnqueueMessage(new ConfirmResult {
          Status = ConfirmResult.ConfirmStatus.Resent
        });
      } catch (Exception ex) {
        EnqueueMessage(new ConfirmResult {
          ErrorMessage = ex.Message,
          InnerException = ex,
          Status = ConfirmResult.ConfirmStatus.Error
        });
      }
    }
  }
}
