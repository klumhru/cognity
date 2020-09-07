
data "aws_iam_policy_document" "authenticated_user" {
  statement {
    effect = "Allow"
    actions = [
      "mobileanalytics:PutEvents",
      "cognito-sync:*",
      "cognito-identity:*"
    ]
    resources = ["*"]
  }
}

resource "aws_iam_policy" "authenticated_user" {
  policy = data.aws_iam_policy_document.authenticated_user.json
  name   = "${local.name_prefix}-authenticated-user"
}

data "aws_iam_policy_document" "authenticated_user_assume" {
  statement {
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

resource "aws_iam_role" "authenticated_user" {
  name               = "${local.name_prefix}-authenticated-user"
  assume_role_policy = data.aws_iam_policy_document.authenticated_user_assume.json
}


data "aws_iam_policy_document" "unauthenticated_user" {
  statement {
    effect = "Allow"
    actions = [
      "mobileanalytics:PutEvents",
      "cognito-sync:*",
    ]
    resources = ["*"]
  }
}

resource "aws_iam_policy" "unauthenticated_user" {
  policy = data.aws_iam_policy_document.unauthenticated_user.json
  name   = "${local.name_prefix}-unauthenticated-user"
}

data "aws_iam_policy_document" "unauthenticated_user_assume" {
  statement {
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
      values   = ["unauthenticated"]
    }
  }
}

resource "aws_iam_role" "unauthenticated_user" {
  name               = "${local.name_prefix}-unauthenticated-user"
  assume_role_policy = data.aws_iam_policy_document.unauthenticated_user_assume.json
}
