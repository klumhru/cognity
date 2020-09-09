package options

type aws struct {
	Region string `long:"aws-region" env:"AWS_REGION"`
}

// AWS are aws specific environment variables
var AWS = aws{}

func init() {
	registry[option{"aws", "AWS environment"}] = &AWS
}
