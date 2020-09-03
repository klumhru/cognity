resource "aws_cognito_user_pool" "cognity" {
  name = "${local.name_prefix}-user-pool"
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
