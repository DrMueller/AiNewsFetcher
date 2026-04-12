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
  app_settings                       = {}
  client_certificate_enabled         = false
  client_certificate_mode            = "Required"
  enabled                            = true
  http_concurrency                   = 0
  https_only                         = true
  instance_memory_in_mb              = 512
  location                           = var.region
  maximum_instance_count             = 100
  name                               = var.app_name
  public_network_access_enabled      = true
  resource_group_name                = var.resource_group_name
  runtime_name                       = "dotnet-isolated"
  runtime_version                    = "10.0"
  service_plan_id                    = "/subscriptions/91660754-3529-407f-8458-92759935fbf7/resourceGroups/matthias/providers/Microsoft.Web/serverFarms/ASP-Matthias-adaa"
  storage_authentication_type        = "StorageAccountConnectionString"
  storage_container_endpoint         = "https://matthiasstorage.blob.core.windows.net/app-package-ainewsfetcher-0809eed"
  storage_container_type             = "blobContainer"
  tags = {
    "hidden-link: /app-insights-resource-id" = "/subscriptions/91660754-3529-407f-8458-92759935fbf7/resourceGroups/Matthias/providers/microsoft.insights/components/MatthiasAppInsights"
  }
  webdeploy_publish_basic_authentication_enabled = false
  site_config {
    application_insights_connection_string        = var.app_insights_connection_string
    container_registry_use_managed_identity       = false
    default_documents                             = ["Default.htm", "Default.html", "Default.asp", "index.htm", "index.html", "iisstart.htm", "default.aspx", "index.php"]
    elastic_instance_minimum                      = 0
    health_check_eviction_time_in_min             = 0
    http2_enabled                                 = false
    load_balancing_mode                           = "LeastRequests"
    managed_pipeline_mode                         = "Integrated"
    minimum_tls_version                           = "1.2"
    remote_debugging_enabled                      = false
    remote_debugging_version                      = "VS2022"
    runtime_scale_monitoring_enabled              = false
    scm_minimum_tls_version                       = "1.2"
    scm_use_main_ip_restriction                   = false
    use_32_bit_worker                             = false
    vnet_route_all_enabled                        = false
    websockets_enabled                            = false
    worker_count                                  = 1
    cors {
      allowed_origins     = ["https://portal.azure.com"]
      support_credentials = false
    }
  }
}
