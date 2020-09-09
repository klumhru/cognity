package handler

import (
	"fmt"
	"reflect"
	"testing"

	"github.com/aws/aws-sdk-go/service/sqs/sqsiface"
)

func TestNew(t *testing.T) {
	type args struct {
		sqsAPI sqsiface.SQSAPI
	}
	tests := []struct {
		name    string
		args    args
		want    *Handler
		wantErr bool
	}{
		{
			"Test with valid sqs",
			args{&sqsmock{nil, nil, nil}},
			&Handler{&sqsmock{nil, nil, nil}},
			false,
		},
		{
			"Test with invalid sqs",
			args{&sqsmock{nil, nil, fmt.Errorf("Mock error")}},
			nil,
			true,
		},
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			got, err := New(tt.args.sqsAPI)
			if (err != nil) != tt.wantErr {
				t.Errorf("New() error = %v, wantErr %v", err, tt.wantErr)
				return
			}
			if !reflect.DeepEqual(got, tt.want) {
				t.Errorf("New() = %v, want %v", got, tt.want)
			}
		})
	}
}
