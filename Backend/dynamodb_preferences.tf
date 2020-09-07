resource "aws_dynamodb_table" "preferences" {
  name     = "${local.name_prefix}-player-preferences"
  hash_key = "UserId"
  attribute {
    name = "UserId"
    type = "S"
  }
  billing_mode = "PAY_PER_REQUEST"
}
