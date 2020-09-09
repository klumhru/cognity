package options

type cognito struct {
	DefaultGroup string `long:"cognito-default-group" env:"COGNITO_DEFAULT_GROUP" default:"Players"`
}

// Cognito contains common options for cognito business logic
var Cognito = cognito{}

func init() {
	registry[option{"cognito", "Cognito Configuration"}] = &Cognito
}
