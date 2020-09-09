package handler

import (
	"context"
	"fmt"

	"github.com/aws/aws-lambda-go/events"
	"github.com/aws/aws-sdk-go/service/cognitoidentityprovider"
	"github.com/klumhru/cognity/Lambdas/options"
)

// Handle processes a pre signup event
func (h *Handler) Handle(ctx context.Context, evt events.CognitoEventUserPoolsPreSignup) error {
	in := cognitoidentityprovider.AdminAddUserToGroupInput{
		GroupName:  &options.Cognito.DefaultGroup,
		UserPoolId: &evt.UserPoolID,
		Username:   &evt.UserName,
	}
	_, err := h.cognitoAPI.AdminAddUserToGroup(&in)
	if err != nil {
		return fmt.Errorf("failed to add user %s to group %s: %v",
			evt.UserName, options.Cognito.DefaultGroup, err,
		)
	}
	return nil
}
