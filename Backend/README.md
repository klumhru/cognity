Cognity Backend
===

This terraform stack deploys the resources required to run the Unity AWS Cognito Client (Cognity) package in Unity.

# Initialization

It is recommended to make a copy of the `var-files/example.config.tfvars` and `var-files/example.vars.tfvars` files. These files are covered by `.gitignore` and should not be stored in CVS, but kept in a CI secret somewhere.

A handy set of environment exports would be as follows:

```bash
export TF_CLI_ARGS_init="-backend-config=var-files/cognity.config.tfvars -input=false" \
       TF_CLI_ARGS_plan="-var-file=var-files/cognity.vars.tfvars -input=false -out /tmp/cognity.tfplan" \
       TF_CLI_ARGS_apply="-input=false /tmp/cognity.tfplan"
```

Then just run `terraform init` and the remote state will be initialized

*Note that it is good practice to enable versioning on any bucket used for terraform state*

# Using workspaces

Using workspaces for different deployment stages is a good way to manage remote state. Each state is stored as a separate file, and the workspace name is used internally by the stack to prevent naming collisions. For that reason your workspace name needs to be [DNS compliant](https://tools.ietf.org/html/rfc1123) `[a-z0-9-]{1,26}` - no starting or ending with hyphen.

Set your workspace by running

```bash
terraform workspace list
terraform workspace new <myworkspace>
# OR
terraform workspace select <existingworkspace>
```

# Execution

Adjust any variables and run

```bash
# 1. Plan and Inspect the planned actions carefully
terraform plan

# 2. Apply - this can take a few minutes
terraform apply

# 3. Output the outputs into a json file that the client can read.
terraform output -json > ../Assets/cognito-config.json
```

# A note on sensitive data

This backend sets up a cognito user-pool, a dynamodb table to store user managed data, as well as an identity pool. It's your responsibility to fulfil the regulations of your country concerning storage of personally identifiable data (PII) and the attendant regulations, where applicable, regarding the right to be forgotten and securing sensitive personal information.
