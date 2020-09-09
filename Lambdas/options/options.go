package options

import (
	"github.com/jessevdk/go-flags"
	log "github.com/sirupsen/logrus"
)

type option struct {
	code string
	desc string
}

var (
	registry = map[option]interface{}{}
	logging  = struct {
		Level string `long:"log-level" env:"LOG_LEVEL"`
	}{}
)

// Init initializes option groups
func Init(codes ...string) {

	parser := flags.NewParser(&logging, flags.Default|flags.IgnoreUnknown)
	for _, code := range codes {
		for k, v := range registry {
			if k.code == code {
				parser.AddGroup(k.desc, "", v)
			}
		}
	}
	if _, err := parser.Parse(); err != nil {
		log.Errorf("error parsing options: %v", err)
	}
	lvl, err := log.ParseLevel(logging.Level)
	if err != nil {
		log.Errorf("error parsing log level %s: %v", logging.Level, err)
	}
	log.SetLevel(lvl)
}
