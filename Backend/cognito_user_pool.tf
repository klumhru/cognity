resource "aws_cognito_user_pool" "cognity" {
  name = "${local.name_prefix}-user-pool"

  username_attributes      = ["email"]
  auto_verified_attributes = ["email"]

  password_policy {
    minimum_length    = 8
    require_lowercase = true
    require_symbols   = true
    temporary_password_validity_days = 7
  }

  mfa_configuration = "OPTIONAL"
  software_token_mfa_configuration {
    enabled = true
  }

  schema {
    name                = "email"
    required            = true
    attribute_data_type = "String"
    string_attribute_constraints {
      max_length = 512
      min_length = 3
    }
  }
  schema {
    name                = "nickname"
    required            = true
    attribute_data_type = "String"
    string_attribute_constraints {
      max_length = 512
      min_length = 3
    }
  }
}

resource "aws_cognito_user_pool_client" "players" {
  user_pool_id = aws_cognito_user_pool.cognity.id
  name         = "Players"
}

resource "aws_cognito_user_group" "players" {
  name         = "Players"
  user_pool_id = aws_cognito_user_pool.cognity.id
  description  = "Registered players"
  precedence   = 50
  role_arn     = aws_iam_role.players.arn
}

resource "aws_cognito_user_pool_client" "administrators" {
  user_pool_id = aws_cognito_user_pool.cognity.id
  name         = "Administrators"
}

resource "aws_cognito_user_group" "administrators" {
  name         = "Administrators"
  user_pool_id = aws_cognito_user_pool.cognity.id
  description  = "Registered adminsitrators"
  precedence   = 0
  role_arn     = aws_iam_role.administrators.arn
}
