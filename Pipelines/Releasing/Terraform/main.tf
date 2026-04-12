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

resource "azurerm_service_plan" "res" {
  name                = var.app_name
  location            = var.region
  resource_group_name = var.resource_group_name

  os_type  = "Windows"
  sku_name = "Y1" # Consumption Plan für Functions
}

data "azurerm_storage_account" "existing" {
  name                = var.storage_account_name
  resource_group_name = var.resource_group_name
}

resource "azurerm_windows_function_app" "res" {
  name                = var.app_name
  location            = var.region
  resource_group_name = var.resource_group_name
  service_plan_id     = azurerm_service_plan.res.id

  storage_account_name       = data.azurerm_storage_account.existing.name
  storage_account_access_key = data.azurerm_storage_account.existing.primary_access_key

  site_config {
    application_insights_connection_string =  var.app_insights_connection_string
    application_stack {
      dotnet_version = "v6.0"
    }
  }

  app_settings = {
    "AppName"                     = var.app_name
    "FUNCTIONS_WORKER_RUNTIME"    = "dotnet"
  }
}