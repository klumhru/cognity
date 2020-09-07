data "aws_iam_policy_document" "players_assume" {
  statement {
    sid    = "playersassume"
    effect = "Allow"
    principals {
      type        = "Federated"
      identifiers = ["cognito-identity.amazonaws.com"]
    }
    actions = ["sts:AssumeRoleWithWebIdentity"]
    condition {
      test     = "StringEquals"
      variable = "cognito-identity.amazonaws.com:aud"
      values   = [aws_cognito_identity_pool.cognity.id]
    }
    condition {
      test     = "ForAnyValue:StringLike"
      variable = "cognito-identity.amazonaws.com:amr"
      values   = ["authenticated"]
    }
  }
}

resource "aws_iam_role" "players" {
  name               = "${local.name_prefix}-players-role"
  assume_role_policy = data.aws_iam_policy_document.players_assume.json
}

data "aws_iam_policy_document" "player_preferences" {
  statement {
    sid    = "editprefs"
    effect = "Allow"
    actions = [
      "dynamodb:GetItem",
      "dynamodb:PutItem",
      "dynamodb:Query"
    ]
    resources = [aws_dynamodb_table.preferences.arn]
    condition {
      test     = "ForAllValues:StringEquals"
      variable = "dynamodb:LeadingKeys"
      values   = ["$${cognito-identity.amazonaws.com:sub}"]
    }
  }
}

resource "aws_iam_policy" "player_preferences" {
  policy = data.aws_iam_policy_document.player_preferences.json
  name   = "${local.name_prefix}-player-preferences"
}

resource "aws_iam_role_policy_attachment" "player_preferences" {
  role       = aws_iam_role.players.name
  policy_arn = aws_iam_policy.player_preferences.arn
}

data "aws_iam_policy_document" "administrators_assume" {
  statement {
    sid    = "administratorsassume"
    effect = "Allow"
    principals {
      type        = "Federated"
      identifiers = ["cognito-identity.amazonaws.com"]
    }
    actions = ["sts:AssumeRoleWithWebIdentity"]
    condition {
      test     = "StringEquals"
      variable = "cognito-identity.amazonaws.com:aud"
      values   = [aws_cognito_identity_pool.cognity.id]
    }
    condition {
      test     = "ForAnyValue:StringLike"
      variable = "cognito-identity.amazonaws.com:amr"
      values   = ["authenticated"]
    }
  }
}

resource "aws_iam_role" "administrators" {
  name               = "${local.name_prefix}-administrators-role"
  assume_role_policy = data.aws_iam_policy_document.administrators_assume.json
}
