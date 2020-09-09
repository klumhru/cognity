package options

import (
	"github.com/jessevdk/go-flags"
	log "github.com/sirupsen/logrus"
)

type option struct {
	code string
	desc string
}

type logging struct {
	Level string `long:"log-level" env:"LOG_LEVEL" default:"warn"`
}

var (
	registry = map[option]interface{}{}
	// Logging options
	Logging = logging{}
)

// Init initializes option groups
func Init(codes ...string) {

	parser := flags.NewParser(&Logging, flags.Default|flags.IgnoreUnknown)
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
	lvl, err := log.ParseLevel(Logging.Level)
	if err != nil {
		log.Errorf("error parsing log level %s: %v", Logging.Level, err)
	}
	log.SetLevel(lvl)
}
