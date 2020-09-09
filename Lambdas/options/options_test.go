package options

import (
	"os"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestInit(t *testing.T) {
	type args struct {
		codes []string
	}
	type env map[string]string
	type want struct {
		aws     aws
		cognito cognito
		sqs     sqs
		logging logging
	}
	tests := []struct {
		name string
		args args
		env  env
		want want
	}{
		{
			"Test all",
			args{[]string{"aws", "cognito", "sqs"}},
			env{
				"AWS_REGION":            "moon-midlands-1",
				"COGNITO_DEFAULT_GROUP": "Baristas",
				"SQS_QUEUE_URL":         "foo/bar",
			},
			want{
				aws:     aws{Region: "moon-midlands-1"},
				cognito: cognito{DefaultGroup: "Baristas"},
				sqs:     sqs{QueueURL: "foo/bar"},
				logging: logging{Level: "warn"},
			},
		},
	}
	assert := assert.New(t)
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			for k, v := range tt.env {
				os.Setenv(k, v)
			}
			Init(tt.args.codes...)
			got := want{
				aws:     AWS,
				cognito: Cognito,
				sqs:     SQS,
				logging: Logging,
			}
			assert.EqualValuesf(tt.want, got, "%s: options not equal", tt.name)
		})
	}
}
