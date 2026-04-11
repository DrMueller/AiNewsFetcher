terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0"
    }
  }

  backend "azurerm" {
    resource_group_name  = "matthias"
    storage_account_name = "terraformstuff"
    container_name       = "terraformstuffblob"
    key                  = "tf/terraform.tfstate"
  }
}

provider "azurerm" {
  subscription_id = var.subscription_id
  tenant_id       = "d6fddda6-f690-4755-92c2-f22a3521bab0"

  features {}
}

locals {
  base_name = substr(
    lower(replace("${var.environment_prefix}${var.app_name}", "/[^a-z0-9]/", "")),
    0,
    24
  )
}

resource "azurerm_service_plan" "res" {
  name                = local.base_name
  location            = var.region
  resource_group_name = var.resource_group_name

  os_type  = "Windows"
  sku_name = "Y1" # Consumption Plan für Functions
}

resource "azurerm_storage_account" "res" {
  name                     = local.base_name
  resource_group_name      = var.resource_group_name
  location                 = var.region
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_windows_function_app" "res" {
  name                = local.base_name
  location            = var.region
  resource_group_name = var.resource_group_name
  service_plan_id     = azurerm_service_plan.res.id

  storage_account_name       = azurerm_storage_account.res.name
  storage_account_access_key = azurerm_storage_account.res.primary_access_key

  site_config {
    application_stack {
      dotnet_version = "v6.0"
    }
  }

  app_settings = {
    "AppName"                = var.app_name
    "AzureWebJobsStorage"   = azurerm_storage_account.res.primary_connection_string
    "FUNCTIONS_WORKER_RUNTIME" = "dotnet"
  }
}