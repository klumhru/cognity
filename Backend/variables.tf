variable "aws_region" {
  description = "AWS Deployment Region"
  type        = string
  default     = "us-east-1"
}

variable "project_short" {
  type        = string
  description = "DNS compliant short name for the project"
  default     = "cognity"
}
