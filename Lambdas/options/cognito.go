package options

// Cognito contains common options for cognito business logic
var Cognito = struct {
	DefaultGroup string `long:"cognito-default-group" env:"COGNITO_DEFAULT_GROUP" default:"Players"`
}{}

func init() {
	registry[option{"cognito", "Cognito Configuration"}] = &Cognito
}
