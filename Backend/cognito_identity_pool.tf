resource "aws_cognito_identity_pool" "cognity" {
  identity_pool_name               = "${replace(local.name_prefix, "-", " ")} identities"
  allow_unauthenticated_identities = false

  cognito_identity_providers {
    client_id               = aws_cognito_user_pool_client.players.id
    provider_name           = aws_cognito_user_pool.cognity.endpoint
    server_side_token_check = false
  }

  cognito_identity_providers {
    client_id               = aws_cognito_user_pool_client.administrators.id
    provider_name           = aws_cognito_user_pool.cognity.endpoint
    server_side_token_check = false
  }
}

resource "aws_cognito_identity_pool_roles_attachment" "cognity" {
  identity_pool_id = aws_cognito_identity_pool.cognity.id
  roles = {
    "authenticated"   = aws_iam_role.authenticated_user.arn
    "unauthenticated" = aws_iam_role.unauthenticated_user.arn
  }
}
