package options

// AWS are aws specific environment variables
var AWS = struct {
	Region string `long:"aws-region" env:"AWS_REGION"`
}{}

func init() {
	registry[option{"aws", "AWS environment"}] = &AWS
}
