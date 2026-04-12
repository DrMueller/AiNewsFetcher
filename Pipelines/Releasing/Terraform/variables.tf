variable "region" {
  type    = string
  default = "West Europe"
}

variable "subscription_id" {
  type    = string
  default = "91660754-3529-407f-8458-92759935fbf7"
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