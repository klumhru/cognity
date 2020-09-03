output "cognito" {
  description = "Cognito output values. Use terraform output with -json to get a file readable by the client."
  value = {
    identity_pool_id = aws_cognito_identity_pool.cognity.id
    user_pool_id     = aws_cognito_user_pool.cognity.id
  }
}
