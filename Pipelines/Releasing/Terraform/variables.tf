variable "region" {
  type    = string
  default = "West Europe"
}

variable "subscription_id" {
  type    = string
  default = "91660754-3529-407f-8458-92759935fbf7"
}

variable "tenant_id" {
  type    = string
  default = "d6fddda6-f690-4755-92c2-f22a3521bab0"
}

variable "storage_account_name" {
  type = string
  default = "matthiasstorage"
}

variable "resource_group_name" {
  type = string
  default = "matthias"
}

variable "appinsights_name" {
  type = string
  default = "matthias"
}

# Varaibles set via azure devops task env variables

variable "app_name" {
  type = string
}

variable "app_insights_connection_string" {
  type = string
}

variable "app_settings_open_ai_endpoint" {
  type = string
}

variable "app_settings_open_ai_key" {
  type = string
}

variable "app_settings_open_ai_deployment_name" {
  type = string
}

variable "app_settings_smtp_user" {
  type = string
}

variable "app_settings_smtp_password" {
  type = string
}



      # TF_VAR_app_insights_connection_string: $(ApplicationInsights.ConnectionString)
      # TF_VAR_app_settings_open_ai_endpoint: $(OpenAiEndpoint)
      # TF_VAR_app_settings_open_ai_key: $(OpenAiKey)
      # TF_VAR_app_settings_open_ai_deployment_name: $(OpenAiDeploymentName)
      # TF_VAR_app_settings_smtp_user: $(SmtpUser)
      # TF_VAR_app_settings_smtp_password: $(SmtpPassword)