package handler

import "github.com/aws/aws-sdk-go/service/cognitoidentityprovider/cognitoidentityprovideriface"

// Handler handles requests for the pre-signup cognito lambda trigger
type Handler struct {
	cognitoAPI cognitoidentityprovideriface.CognitoIdentityProviderAPI
}

// New returns a new Handler instance
func New(cognitoAPI cognitoidentityprovideriface.CognitoIdentityProviderAPI) (*Handler, error) {
	return &Handler{
		cognitoAPI: cognitoAPI,
	}, nil
}
