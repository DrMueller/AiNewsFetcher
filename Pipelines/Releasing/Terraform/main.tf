terraform {
  required_providers {
    azurerm = {
      source  = "azurerm"
      version = "4.58.0"
    }
  }
  # The values are needed for local commands like creating the workspaces
  backend "azurerm" {
    resource_group_name  = "TerraformStuff"
    storage_account_name = "terraformstuffblob"
    container_name       = "terraformstuffblobcontainer"
    key                  = "tf/terraform.tfstate"
  }
}

provider "azurerm" {
  subscription_id = var.subscription_id
  tenant_id       = var.tenant_id
  features {
  }
}

resource "azurerm_function_app_flex_consumption" "res-0" {
  app_settings = {
    "AppSettings__OpenAiDeploymentName" = var.app_settings_open_ai_deployment_name
    "AppSettings__OpenAiEndpoint"       = var.app_settings_open_ai_endpoint
    "AppSettings__OpenAiKey"            = var.app_settings_open_ai_key
    "AppSettings__SmtpUser"             = var.app_settings_smtp_user
    "AppSettings__SmtpPassword"         = var.app_settings_smtp_password
  }
  service_plan_id                    = "/subscriptions/91660754-3529-407f-8458-92759935fbf7/resourceGroups/matthias/providers/Microsoft.Web/serverFarms/ASP-Matthias-b5d4"
  client_certificate_enabled         = false
  client_certificate_mode            = "Required"
  enabled                            = true
  https_only                         = true
  instance_memory_in_mb              = 512
  location                           = var.region
  name                               = var.app_name
  public_network_access_enabled      = true
  resource_group_name                = var.resource_group_name
  runtime_name                       = "dotnet-isolated"
  runtime_version                    = "10.0"
  storage_authentication_type        = "StorageAccountConnectionString"
  storage_container_endpoint         = "https://matthiasstorage.blob.core.windows.net/app-package-ainewsfetcher-0809eed"
  storage_container_type             = "blobContainer"
  tags = {
    "hidden-link: /app-insights-resource-id" = "/subscriptions/91660754-3529-407f-8458-92759935fbf7/resourceGroups/Matthias/providers/microsoft.insights/components/MatthiasAppInsights"
  }
  webdeploy_publish_basic_authentication_enabled = false
  site_config {
    application_insights_connection_string        = var.app_insights_connection_string
    default_documents                             = ["Default.htm", "Default.html", "Default.asp", "index.htm", "index.html", "iisstart.htm", "default.aspx", "index.php"]
    load_balancing_mode                           = "LeastRequests"
    managed_pipeline_mode                         = "Integrated"
    runtime_scale_monitoring_enabled              = false
    scm_minimum_tls_version                       = "1.2"
    cors {
      allowed_origins     = ["https://portal.azure.com"]
      support_credentials = false
    }
  }
}
