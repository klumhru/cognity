terraform {
  backend "s3" {}
}

provider "aws" {
  region = var.aws_region
}

locals {
  name_prefix = "${var.project_short}-${terraform.workspace}"
}
