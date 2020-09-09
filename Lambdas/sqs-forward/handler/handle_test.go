package handler

import (
	"context"
	"fmt"
	"testing"

	"github.com/aws/aws-sdk-go/service/sqs/sqsiface"
	"github.com/klumhru/cognity/Lambdas/event"
)

func TestHandler_Handle(t *testing.T) {
	type fields struct {
		sqsAPI sqsiface.SQSAPI
	}
	type args struct {
		ctx context.Context
		evt *event.Event
	}
	tests := []struct {
		name    string
		fields  fields
		args    args
		wantErr bool
	}{
		{
			"Test with no error",
			fields{
				&sqsmock{nil, nil, nil},
			},
			args{
				context.Background(),
				&event.Event{},
			},
			false,
		},
		{
			"Handle sqs error",
			fields{
				&sqsmock{nil, nil, fmt.Errorf("failed to send")},
			},
			args{
				context.Background(),
				&event.Event{},
			},
			true,
		},
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			h := &Handler{
				sqsAPI: tt.fields.sqsAPI,
			}
			if err := h.Handle(tt.args.ctx, tt.args.evt); (err != nil) != tt.wantErr {
				t.Errorf("Handler.Handle() error = %v, wantErr %v", err, tt.wantErr)
			}
		})
	}
}
